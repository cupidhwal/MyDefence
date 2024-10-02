using UnityEngine;

namespace MyDefence
{
    public class LevelClearUI : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        public GameObject warningUI;

        public string keyName = "NowLevel";
        [SerializeField] private string nextScene = "Level02";
        [SerializeField] private string loadToScene = "MainMenu";
        #endregion

        public void Continue()
        {
            if (PlayerPrefs.GetInt(keyName) >= 3)
            {
                warningUI.SetActive(true);
            }

            else
                fader.FadeTo(nextScene);
        }

        public void Menu()
        {
            fader.FadeTo(loadToScene);
        }
    }
}