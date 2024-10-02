using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyDefence
{
    public class CameraManager : MonoBehaviour
    {
        #region
        //�ʵ�
        private float moveSpeed;
        private float border;
        private float minHeight;
        private float maxHeight;

        private float hMove;
        private float vMove;

        private float mouseX;
        private float mouseY;

        private bool isLocked = false;

        private Transform cameraTransform;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            //rectTransform = canvas.GetComponent<RectTransform>();
            cameraTransform = this.transform;

            moveSpeed = 15f;
            border = 10f;
            minHeight = 10f;
            maxHeight = 40f;
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.IsGameOver) return;

            if (Input.GetKeyDown(KeyCode.Escape))
                isLocked = !isLocked;

            if (isLocked) return;



            //Ű �Է¿� ���� ��ũ�� �̵�
            hMove = Input.GetAxis("Horizontal") * Time.deltaTime;
            vMove = Input.GetAxis("Vertical") * Time.deltaTime;

            cameraTransform.position += new Vector3(hMove * moveSpeed, 0, vMove * moveSpeed);



            //���콺 ��� ���� ��ũ�� �̵�
            mouseX = Input.mousePosition.x;
            mouseY = Input.mousePosition.y;

            float moveScroll = moveSpeed * Time.deltaTime;

            if (mouseX < border)
                cameraTransform.position += new Vector3(-moveScroll, 0, 0);

            if (mouseY < border)
                cameraTransform.position += new Vector3(0, 0, -moveScroll);

            if (Screen.width - mouseX < border)
                cameraTransform.position += new Vector3(moveScroll, 0, 0);

            if (Screen.height - mouseY < border)
                cameraTransform.position += new Vector3(0, 0, moveScroll);



            //���콺 �� �Է¿� ���� ��ũ�� �̵�
            float moveHeight = Input.GetAxis("Mouse ScrollWheel") * 10;
            float currentHeight = cameraTransform.position.y + moveHeight;

            currentHeight = Mathf.Clamp(currentHeight, minHeight, maxHeight);

            cameraTransform.position = new Vector3(cameraTransform.position.x, currentHeight, cameraTransform.position.z);
        }
    }
}