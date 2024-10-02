using UnityEngine;
using UnityEngine.InputSystem;

namespace Sample
{
    public class PlayerMoveTest : MonoBehaviour
    {
        //필드
        #region Variables
        //컨트롤 획득
        private Controls control;

        //단순 변수
        private float moveSpeed;

        //복합 변수
        private Vector2 moveInput;
        private Vector3 moveDirection;

        //컴포넌트
        private Rigidbody rb;
        public Transform target;



        //기타 필드
        public Transform firePoint;
        public GameObject bulletPrefab;
        #endregion

        //라이프 사이클
        #region Life Cycle
        // Start is called before the first frame update
        void Start()
        {
            moveSpeed = 5;

            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            //wasd 입력을 받아 이동 구현
            Move();

            //항상 타겟을 바라보도록 구현(총구를 자동으로 타게팅)
            Look();
        }

        private void Awake()
        {
            control = new Controls();

            control.Player.Move.performed += OnMovePerformed;
            control.Player.Move.canceled += OnMoveCanceled;

            control.Player.Fire.performed += OnFirePerformed;
        }

        private void OnEnable()
        {
            control.Player.Enable();
        }

        private void OnDisable()
        {
            control.Player.Disable();
        }
        #endregion

        //이벤트 핸들러
        #region Event Handlers
        //이벤트 핸들러
        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>().normalized;
            moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        }

        private void OnMoveCanceled(InputAction.CallbackContext context)
        {
            moveInput = Vector2.zero;
        }

        private void OnFirePerformed(InputAction.CallbackContext context)
        {
            //탄환 발사
            Fire();
        }
        #endregion

        //이동 관련 메서드
        #region Methods
        void Move()
        {
            Vector3 move = moveDirection * Time.deltaTime;
            rb.MovePosition(rb.position + move * moveSpeed);

            MoveDirection(ref moveDirection);
        }

        void Look()
        {
            Vector3 direction = target.position - this.transform.position;
            this.transform.rotation = Quaternion.LookRotation(direction);
        }

        void MoveDirection(ref Vector3 direction)
        {
            // 정면 방향을 기준으로 이동 방향을 계산
            Vector3 forward = transform.forward;
            Vector3 right = transform.right;

            forward.y = 0; // y축 제거
            right.y = 0;   // y축 제거

            forward.Normalize();
            right.Normalize();

            // 카메라 방향을 기반으로 이동 방향 계산
            direction = forward * moveInput.y + right * moveInput.x;
        }
        #endregion

        //공격 관련 메서드
        #region Atk Methods
        void Fire()
        {
            GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            BulletTest bulletTest = bulletGo.GetComponent<BulletTest>();

            Debug.Log("탄환 생성됨: " + bulletGo.name);

            if (bulletTest != null)
            {
                bulletTest.MoveForward();
            }

            Destroy(bulletGo, 3f);
        }
        #endregion
    }
}