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

            // ��ư ���� �ʱ�ȭ
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

            //���� �� �ҷ�����
            sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        }

        public void MenuButton()
        {
            Time.timeScale = 1f;

            sceneFader.FadeTo(loadToScene);
        }

        // ��ư ���¸� �����ϴ� �޼���
        private void ResetButtonState()
        {
            continueButton.interactable = true;
            retryButton.interactable = true;
            menuButton.interactable = true;

            // EventSystem�� ����Ͽ� ���� ���� �ʱ�ȭ
            EventSystem.current.SetSelectedGameObject(null);
        }
        #endregion
    }
}