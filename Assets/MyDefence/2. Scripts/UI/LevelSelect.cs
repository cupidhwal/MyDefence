using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MyDefence
{
    public class LevelSelect : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        //����� ���� ��������
        public string keyName = "NowLevel";

        //���� ��ư ��������
        public Transform contents;
        private Button[] levelButtons;

        //������Ʈ
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
            //����� ������ ��������
            int nowLevel = PlayerPrefs.GetInt(keyName, 1);
            Debug.Log($"������ nowLevel: {nowLevel}");

            //���� ��ư ��������
            levelButtons = new Button[contents.childCount];

            //���� ��ư unlock
            for (int i = 0; i < levelButtons.Length; i++)
            {
                Transform child = contents.GetChild(i);
                levelButtons[i] = child.GetComponent<Button>();

                if (i < nowLevel)
                    levelButtons[i].interactable = true;
            }

            //��ũ��  ����
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
// ���� ������ Save/Load
- ����(����̽�) : ����,
- ���� : �����ͺ��̽�

PlayerPrefs
PlayerPrefs.SetInt(string KeyName, int Value);      // KeyName���� value �� �����ϱ�(save)
PlayerPrefs.GetInt(string KeyName);                 // KeyName���� ����� value �� ��������(load)

PlayerPrefs.SetFloat(string KeyName, float Value);  // KeyName���� value �� �����ϱ�(save)
PlayerPrefs.GetFloat(string KeyName);               // KeyName���� ����� value �� ��������(load)

PlayerPrefs.SetString(string KeyName, string Value);// KeyName���� value �� �����ϱ�(save)
PlayerPrefs.GetString(string KeyName);              // KeyName���� ����� value �� ��������(load)
*/