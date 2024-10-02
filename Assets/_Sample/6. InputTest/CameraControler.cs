using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sample
{
    //뉴 인풋 시스템으로 카메라 제어
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

            //마우스 제어에 따른 스크린 이동
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

            //휠 스크롤
            Vector2 scroll = Mouse.current.scroll.ReadValue();

            //마우스 휠 입력에 따른 스크린 이동
            float moveHeight = Input.GetAxis("Mouse ScrollWheel") * 10;
            float currentHeight = cameraTransform.position.y + moveHeight;

            currentHeight = Mathf.Clamp(currentHeight, minHeight, maxHeight);

            cameraTransform.position = new Vector3(cameraTransform.position.x, currentHeight, cameraTransform.position.z);*/
        }

        //Unity Event : 메서드 등록
        public void Move(InputAction.CallbackContext context)
        {
            inputVector = context.ReadValue<Vector2>();
        }

        public void MousePos(InputAction.CallbackContext context)
        {
            //inputVector = context.
        }

        //SendMessages 이용 : 함수 이름 - On + 액션 이름 - 알아서 찾아 실행
        public void OnMove(InputValue value)
        {
            inputVector = value.Get<Vector2>();
        }
    }
}