using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sample
{
    //�� ��ǲ �ý������� ī�޶� ����
    public class CameraControler : MonoBehaviour
    {
        #region Variables
        private float moveSpeed;
        /*private float border;
        private float minHeight;
        private float maxHeight;*/

        Vector2 inputVector;

        private MyInputAction inputActions;
        #endregion

        private void Awake()
        {
            inputActions = new MyInputAction();
        }

        private void OnEnable()
        {
            inputActions.Camera.Enable();
        }

        private void OnDisable()
        {
            inputActions.Camera.Disable();
        }

        private void Start()
        {
            moveSpeed = 10f;
            /*border = 10f;
            minHeight = 10f;
            maxHeight = 40f;*/
        }

        // Update is called once per frame
        void Update()
        {
            //Camera Move
            Vector2 inputVector = inputActions.Camera.Move.ReadValue<Vector2>();
            Vector3 dir = new Vector3(inputVector.x, 0, inputVector.y);
            transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);

            Vector2 mousePos = inputActions.Camera.MousePos.ReadValue<Vector2>();

            //���콺 ��� ���� ��ũ�� �̵�
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            float moveScroll = moveSpeed * Time.deltaTime;

            /*if (mouseX < border)
                cameraTransform.position += new Vector3(-moveScroll, 0, 0);

            this.transform.Translate()

            if (mouseY < border)
                cameraTransform.position += new Vector3(0, 0, -moveScroll);

            if (Screen.width - mouseX < border)
                cameraTransform.position += new Vector3(moveScroll, 0, 0);

            if (Screen.height - mouseY < border)
                cameraTransform.position += new Vector3(0, 0, moveScroll);

            //�� ��ũ��
            Vector2 scroll = Mouse.current.scroll.ReadValue();

            //���콺 �� �Է¿� ���� ��ũ�� �̵�
            float moveHeight = Input.GetAxis("Mouse ScrollWheel") * 10;
            float currentHeight = cameraTransform.position.y + moveHeight;

            currentHeight = Mathf.Clamp(currentHeight, minHeight, maxHeight);

            cameraTransform.position = new Vector3(cameraTransform.position.x, currentHeight, cameraTransform.position.z);*/
        }

        //Unity Event : �޼��� ���
        public void Move(InputAction.CallbackContext context)
        {
            inputVector = context.ReadValue<Vector2>();
        }

        public void MousePos(InputAction.CallbackContext context)
        {
            //inputVector = context.
        }

        //SendMessages �̿� : �Լ� �̸� - On + �׼� �̸� - �˾Ƽ� ã�� ����
        public void OnMove(InputValue value)
        {
            inputVector = value.Get<Vector2>();
        }
    }
}