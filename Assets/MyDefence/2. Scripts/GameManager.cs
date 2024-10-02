using TMPro;
using System.Collections;
using UnityEngine;

namespace MyDefence
{
    //게임의 전체 진행을 관리하는 클래스
    public class GameManager : MonoBehaviour
    {
        //필드
        #region Variables
        //게임오버 체크
        private static bool isGameOver = false;
        public static bool IsGameOver => isGameOver;

        [SerializeField] private bool startFlag = false;

        private float countTime = 5f;
        private float currentTime;

        private int waveCount;

        //Wave 데이터 세팅
        public Wave[] waves;

        public TMP_Text countdown;
        public GameObject enemy;
        public GameObject gameOverUI;
        private GameObject start;

        //일시정지 UI
        public PauseUI pauseUI;
        public GameObject levelClearUI;

        public static int enemyAlive;
        public int currentEnemy;

        //레벨 클리어 시 unlock 되는 레벨
        [SerializeField] private string keyName = "NowLevel";
        [SerializeField] private int unlockLevel = 2;

        //다음 레벨로 가기
        public SceneFader fader;
        public GameObject warningUI;

        //치팅 체크
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

            //게임 오버 체크
            if (PlayerStats.Life <= 0 && isGameOver == false)
            {
                GameOver();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
                pauseUI.Pause();

            //치팅
            if (Input.GetKeyDown(KeyCode.M) && isCheat)
                ShowMeTheMoney();

            if (Input.GetKeyDown(KeyCode.O) && isCheat)
                LevelClear();
        }

        void LevelClear()
        {
            //Debug.Log("레벨 클리어!!");

            //다음에 플레이 가능한 레벨
            //저장된 데이터 가져오기
            int nowLevel = PlayerPrefs.GetInt(keyName, 1);
            //Debug.Log($"가져온 nowLevel: {nowLevel}");

            if(unlockLevel > nowLevel)
            {
                PlayerPrefs.SetInt(keyName, unlockLevel);
                //Debug.Log($"저장된 nowLevel: {unlockLevel}");
            }

            //LevelClear 관련 데이터 처리 : 보상, 저장
            //다음에 플레이 가능한 레벨
            PlayerPrefs.SetInt(keyName, unlockLevel);
            Debug.Log($"저장된 nowLevel: {unlockLevel}");

            //UI창 활성화
            levelClearUI.SetActive(true);
        }

        void GameOver()
        {
            isGameOver = true;

            //UI창 활성화
            gameOverUI.SetActive(true);

            //벌
        }

        //머니 치트
        void ShowMeTheMoney()
        {
            if (isCheat)
            PlayerStats.EarnMoney(100000);
        }

        //레벨업 치트
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
                // 반복문이 모두 순회한 뒤 waveCount++이 시행되면 동작하는 코드블럭
                if (waveCount >= waves.Length)
                {
                    startFlag = false;
                    LevelClear();

                    yield break;
                }

                Wave wave = waves[waveCount];

                isClear = false;

                //카운트다운 로직
                while (countTime > 0)
                {
                    countdown.text = currentTime.ToString("0");

                    yield return new WaitForSeconds(1f);

                    countTime--;

                    currentTime = countTime;
                }

                //카운트다운이 0이 되면 텍스트 삭제
                countdown.text = string.Empty;

                //카운트다운 초기화
                countTime = 5f;
                currentTime = countTime;



                //웨이브 로직
                for (int i = 0; i < wave.count; i++)
                {
                    if (start != null)
                    {
                        // 큐브 위치에서 프리팹 생성
                        enemy = Instantiate(wave.enemyPrefab, start.transform.position, Quaternion.identity);
                    }

                    enemyAlive++;

                    yield return new WaitForSeconds(wave.delayTime);
                }

                //라운드 시작
                PlayerStats.Rounds++;



                //웨이브 클리어 체크 로직
                while (!isClear)
                {
                    yield return new WaitForSeconds(1f);
                    isClear = (currentEnemy == 0) ? true : false;
                }
            }
        }
    }
}