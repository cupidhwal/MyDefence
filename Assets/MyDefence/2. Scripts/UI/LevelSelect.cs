using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MyDefence
{
    public class LevelSelect : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        //저장된 레벨 가져오기
        public string keyName = "NowLevel";

        //레벨 버튼 가져오기
        public Transform contents;
        private Button[] levelButtons;

        //컴포넌트
        public Scrollbar scrollbar;
        public RectTransform scrollView;
        public RectTransform contentsRect;

        //WarningUI
        public GameObject warningUI;
        public TextMeshProUGUI warningText;
        #endregion

        #region Life Cycle
        private void Start()
        {
            //저장된 데이터 가져오기
            int nowLevel = PlayerPrefs.GetInt(keyName, 1);
            Debug.Log($"가져온 nowLevel: {nowLevel}");

            //레벨 버튼 가져오기
            levelButtons = new Button[contents.childCount];

            //레벨 버튼 unlock
            for (int i = 0; i < levelButtons.Length; i++)
            {
                Transform child = contents.GetChild(i);
                levelButtons[i] = child.GetComponent<Button>();

                if (i < nowLevel)
                    levelButtons[i].interactable = true;
            }

            //스크롤  높이
            float contentsHeight = 110 + (int)((levelButtons.Length - 1) / 5) * (110 + 10);
            float scrollHeight = contentsHeight - scrollView.rect.height;

            if (scrollHeight > 0)
            {
                float levelHeight = (int)(nowLevel - 1) / 5 * (110 + 5);
                scrollbar.value = 1 - levelHeight / scrollHeight;

                if (scrollbar.value < 0)
                    scrollbar.value = 0;
            }
        }
        #endregion

        public void SelectLevel(string levelName)
        {
            if (PlayerPrefs.GetInt(keyName) >= 3)
            {
                SelectWarning();
            }

            else
                fader.FadeTo(levelName);
        }

        public void SelectWarning()
        {
            warningUI.SetActive(true);
            warningText.text = $"Currently, difficulty level {PlayerPrefs.GetInt(keyName)} and above is not supported. \n The game will start at a previous difficulty level.";
        }

        public void WarningAccept()
        {
            warningUI.SetActive(false);
            fader.FadeTo($"Level0{PlayerPrefs.GetInt(keyName) - 1}");
        }
    }
}

/*
// 게임 데이터 Save/Load
- 로컬(디바이스) : 파일,
- 서버 : 데이터베이스

PlayerPrefs
PlayerPrefs.SetInt(string KeyName, int Value);      // KeyName으로 value 값 저장하기(save)
PlayerPrefs.GetInt(string KeyName);                 // KeyName으로 저장된 value 값 가져오기(load)

PlayerPrefs.SetFloat(string KeyName, float Value);  // KeyName으로 value 값 저장하기(save)
PlayerPrefs.GetFloat(string KeyName);               // KeyName으로 저장된 value 값 가져오기(load)

PlayerPrefs.SetString(string KeyName, string Value);// KeyName으로 value 값 저장하기(save)
PlayerPrefs.GetString(string KeyName);              // KeyName으로 저장된 value 값 가져오기(load)
*/