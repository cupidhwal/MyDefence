using TMPro;
using System.Collections;
using UnityEngine;

namespace MyDefence
{
    //������ ��ü ������ �����ϴ� Ŭ����
    public class GameManager : MonoBehaviour
    {
        //�ʵ�
        #region Variables
        //���ӿ��� üũ
        private static bool isGameOver = false;
        public static bool IsGameOver => isGameOver;

        [SerializeField] private bool startFlag = false;

        private float countTime = 5f;
        private float currentTime;

        private int waveCount;

        //Wave ������ ����
        public Wave[] waves;

        public TMP_Text countdown;
        public GameObject enemy;
        public GameObject gameOverUI;
        private GameObject start;

        //�Ͻ����� UI
        public PauseUI pauseUI;
        public GameObject levelClearUI;

        public static int enemyAlive;
        public int currentEnemy;

        //���� Ŭ���� �� unlock �Ǵ� ����
        [SerializeField] private string keyName = "NowLevel";
        [SerializeField] private int unlockLevel = 2;

        //���� ������ ����
        public SceneFader fader;
        public GameObject warningUI;

        //ġ�� üũ
        public bool isCheat = true;
        #endregion

        public int Wave { get { return waveCount; } }

        // Start is called before the first frame update
        void Start()
        {
            start = GameObject.FindGameObjectWithTag("Respawn");

            currentTime = countTime;

            gameOverUI.SetActive(false);

            isGameOver = false;
        }

        private void Update()
        {
            currentEnemy = enemyAlive;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                startFlag = !startFlag;
                StartCoroutine(Respawn());
            }

            //GameOver();
            if (isGameOver) return;

            //���� ���� üũ
            if (PlayerStats.Life <= 0 && isGameOver == false)
            {
                GameOver();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
                pauseUI.Pause();

            //ġ��
            if (Input.GetKeyDown(KeyCode.M) && isCheat)
                ShowMeTheMoney();

            if (Input.GetKeyDown(KeyCode.O) && isCheat)
                LevelClear();
        }

        void LevelClear()
        {
            //Debug.Log("���� Ŭ����!!");

            //������ �÷��� ������ ����
            //����� ������ ��������
            int nowLevel = PlayerPrefs.GetInt(keyName, 1);
            //Debug.Log($"������ nowLevel: {nowLevel}");

            if(unlockLevel > nowLevel)
            {
                PlayerPrefs.SetInt(keyName, unlockLevel);
                //Debug.Log($"����� nowLevel: {unlockLevel}");
            }

            //LevelClear ���� ������ ó�� : ����, ����
            //������ �÷��� ������ ����
            PlayerPrefs.SetInt(keyName, unlockLevel);
            Debug.Log($"����� nowLevel: {unlockLevel}");

            //UIâ Ȱ��ȭ
            levelClearUI.SetActive(true);
        }

        void GameOver()
        {
            isGameOver = true;

            //UIâ Ȱ��ȭ
            gameOverUI.SetActive(true);

            //��
        }

        //�Ӵ� ġƮ
        void ShowMeTheMoney()
        {
            if (isCheat)
            PlayerStats.EarnMoney(100000);
        }

        //������ ġƮ
        /*void LevelUp100()
        {
            if (isCheat == false)
                return;
            //level += 100;
        }*/

        private IEnumerator Respawn()
        {
            bool isClear;

            for (waveCount = 0; startFlag; waveCount++)
            {
                // �ݺ����� ��� ��ȸ�� �� waveCount++�� ����Ǹ� �����ϴ� �ڵ��
                if (waveCount >= waves.Length)
                {
                    startFlag = false;
                    LevelClear();

                    yield break;
                }

                Wave wave = waves[waveCount];

                isClear = false;

                //ī��Ʈ�ٿ� ����
                while (countTime > 0)
                {
                    countdown.text = currentTime.ToString("0");

                    yield return new WaitForSeconds(1f);

                    countTime--;

                    currentTime = countTime;
                }

                //ī��Ʈ�ٿ��� 0�� �Ǹ� �ؽ�Ʈ ����
                countdown.text = string.Empty;

                //ī��Ʈ�ٿ� �ʱ�ȭ
                countTime = 5f;
                currentTime = countTime;



                //���̺� ����
                for (int i = 0; i < wave.count; i++)
                {
                    if (start != null)
                    {
                        // ť�� ��ġ���� ������ ����
                        enemy = Instantiate(wave.enemyPrefab, start.transform.position, Quaternion.identity);
                    }

                    enemyAlive++;

                    yield return new WaitForSeconds(wave.delayTime);
                }

                //���� ����
                PlayerStats.Rounds++;



                //���̺� Ŭ���� üũ ����
                while (!isClear)
                {
                    yield return new WaitForSeconds(1f);
                    isClear = (currentEnemy == 0) ? true : false;
                }
            }
        }
    }
}