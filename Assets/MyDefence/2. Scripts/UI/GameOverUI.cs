using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class GameOverUI : MonoBehaviour
    {
        #region Variables
        private string loadToScene = "MainMenu";

        public TextMeshProUGUI roundText;

        public SceneFader sceneFader;
        #endregion

        #region Life Cycle
        private void OnEnable()
        {
            GetRound();
        }
        #endregion

        #region Methods
        public void ReTryButton()
        {
            //�� ����� ó�� ������ ���ư���
            //SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);    //�� ���� ��ȣ�� �ε��ϱ�
            //SceneManager.LoadScene(0, LoadSceneMode.Single);              //�� ���� ��ȣ�� �ε��ϱ�
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);     //���� �� �ε��ϱ�

            //���� �� �ҷ�����
            //FadeOut
            sceneFader.FadeTo(SceneManager.GetActiveScene().name);            
        }

        public void MenuButton()
        {
            sceneFader.FadeTo(loadToScene);
        }

        public void GetRound()
        {
            roundText.text = PlayerStats.Rounds.ToString();
        }
        #endregion
    }
}