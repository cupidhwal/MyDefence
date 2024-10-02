using UnityEngine;
using TMPro;

namespace MyDefence
{
    public class WarningUI : MonoBehaviour
    {
        public SceneFader fader;
        public GameObject warningUI;
        public TextMeshProUGUI warningText;

        public string keyName = "NowLevel";

        void OnEnable()
        {
            warningText.text = $"Currently, difficulty level {PlayerPrefs.GetInt(keyName)} and above is not supported. \n The game will start at a previous difficulty level.";
        }

        public void WarningAccept()
        {
            warningUI.SetActive(false);
            fader.FadeTo($"Level0{PlayerPrefs.GetInt(keyName) - 1}");
        }
    }
}