using UnityEngine;
using TMPro;

namespace MyDefence
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        private string loadToScene = "LevelSelect";
        public SceneFader fader;

        // 레벨 리셋 경고
        public GameObject ResetUI;
        public TextMeshProUGUI warningText;
        #endregion

        public void Play()
        {
            fader.FadeTo(loadToScene);
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void ResetButton()
        {
            ResetUI.SetActive(true);
            ResetWarning();
        }

        public void LevelResetAccept()
        {
            PlayerPrefs.DeleteAll();
            ResetUI.SetActive(false);
        }

        public void LevelResetCancel()
        {
            ResetUI.SetActive(false);
        }

        public void ResetWarning()
        {
            warningText.text = "Reset your save data.";
        }
    }
}