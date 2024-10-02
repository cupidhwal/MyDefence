using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace MyDefence
{
    public class PauseUI : MonoBehaviour
    {
        private bool isPaused = false;

        public Button continueButton;
        public Button retryButton;
        public Button menuButton;

        public SceneFader sceneFader;
        public string loadToScene = "MainMenu";

        #region Life Cycle
        private void OnEnable()
        {
            Time.timeScale = 0f;

            // 버튼 상태 초기화
            ResetButtonState();
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
        }
        #endregion

        #region Methods
        public void Pause()
        {
            isPaused = !isPaused;
            this.gameObject.SetActive(isPaused);
        }

        public void ReTryButton()
        {
            Time.timeScale = 1f;

            //현재 씬 불러오기
            sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        }

        public void MenuButton()
        {
            Time.timeScale = 1f;

            sceneFader.FadeTo(loadToScene);
        }

        // 버튼 상태를 리셋하는 메서드
        private void ResetButtonState()
        {
            continueButton.interactable = true;
            retryButton.interactable = true;
            menuButton.interactable = true;

            // EventSystem을 사용하여 선택 상태 초기화
            EventSystem.current.SetSelectedGameObject(null);
        }
        #endregion
    }
}