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
            //이 방법은 처음 씬으로 돌아가기
            //SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);    //씬 빌드 번호로 로드하기
            //SceneManager.LoadScene(0, LoadSceneMode.Single);              //씬 빌드 번호로 로드하기
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);     //현재 씬 로드하기

            //현재 씬 불러오기
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