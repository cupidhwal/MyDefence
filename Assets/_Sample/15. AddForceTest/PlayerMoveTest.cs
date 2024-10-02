using UnityEngine;
using UnityEngine.InputSystem;

namespace Sample
{
    public class PlayerMoveTest : MonoBehaviour
    {
        //�ʵ�
        #region Variables
        //��Ʈ�� ȹ��
        private Controls control;

        //�ܼ� ����
        private float moveSpeed;

        //���� ����
        private Vector2 moveInput;
        private Vector3 moveDirection;

        //������Ʈ
        private Rigidbody rb;
        public Transform target;



        //��Ÿ �ʵ�
        public Transform firePoint;
        public GameObject bulletPrefab;
        #endregion

        //������ ����Ŭ
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
            //wasd �Է��� �޾� �̵� ����
            Move();

            //�׻� Ÿ���� �ٶ󺸵��� ����(�ѱ��� �ڵ����� Ÿ����)
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

        //�̺�Ʈ �ڵ鷯
        #region Event Handlers
        //�̺�Ʈ �ڵ鷯
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
            //źȯ �߻�
            Fire();
        }
        #endregion

        //�̵� ���� �޼���
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
            // ���� ������ �������� �̵� ������ ���
            Vector3 forward = transform.forward;
            Vector3 right = transform.right;

            forward.y = 0; // y�� ����
            right.y = 0;   // y�� ����

            forward.Normalize();
            right.Normalize();

            // ī�޶� ������ ������� �̵� ���� ���
            direction = forward * moveInput.y + right * moveInput.x;
        }
        #endregion

        //���� ���� �޼���
        #region Atk Methods
        void Fire()
        {
            GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            BulletTest bulletTest = bulletGo.GetComponent<BulletTest>();

            Debug.Log("źȯ ������: " + bulletGo.name);

            if (bulletTest != null)
            {
                bulletTest.MoveForward();
            }

            Destroy(bulletGo, 3f);
        }
        #endregion
    }
}