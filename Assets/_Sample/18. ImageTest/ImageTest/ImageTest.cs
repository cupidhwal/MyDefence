using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class ImageTest : MonoBehaviour
    {
        #region Variables
        // 필드
        // 변수
        [SerializeField] private float coolDownTimer;
        private float coolDown;
        private bool isSkilled;

        // 컴포넌트
        public Image skillImage;
        public Button skillButton;
        public Animator skillAnimator;
        #endregion

        // 라이프 사이클
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
        // 스킬 사용 메서드
        public void SkillUse()
        {
            Debug.Log("스킬 사용");
            isSkilled = true;

            SkillCheck();
        }

        // 스킬 상태 확인 메서드
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

        // 스킬 타이머 메서드
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