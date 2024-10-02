using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class ImageTest : MonoBehaviour
    {
        #region Variables
        // �ʵ�
        // ����
        [SerializeField] private float coolDownTimer;
        private float coolDown;
        private bool isSkilled;

        // ������Ʈ
        public Image skillImage;
        public Button skillButton;
        public Animator skillAnimator;
        #endregion

        // ������ ����Ŭ
        #region Life Cycle
        private void Start()
        {
            coolDownTimer = 5f;
            coolDown = 0;

            isSkilled = false;

            SkillCheck();
        }

        // Update is called once per frame
        void Update()
        {
            SkillTimer();
        }
        #endregion

        #region Methods
        // ��ų ��� �޼���
        public void SkillUse()
        {
            Debug.Log("��ų ���");
            isSkilled = true;

            SkillCheck();
        }

        // ��ų ���� Ȯ�� �޼���
        private void SkillCheck()
        {
            if (isSkilled == true)
            {
                skillButton.interactable = false;
                skillAnimator.enabled = true;
            }

            else
            {
                skillButton.interactable = true;
                skillAnimator.enabled = false;
                skillAnimator.Rebind();
            }
        }

        // ��ų Ÿ�̸� �޼���
        private void SkillTimer()
        {
            if (isSkilled == true && coolDown > 0)
                coolDown -= Time.deltaTime;

            else
            {
                isSkilled = false;
                coolDown = coolDownTimer;
                SkillCheck();
            }
        }
        #endregion
    }
}