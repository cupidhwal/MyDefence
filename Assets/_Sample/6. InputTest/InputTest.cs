using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Sample
{
    public class InputTest : MonoBehaviour
    {
        //필드
        public TextMeshProUGUI xText;
        public TextMeshProUGUI yText;

        // Start is called before the first frame update
        void Start()
        {
            //스크린의 크기
            Debug.Log($"Screen Width : {Screen.width}, Screen Height : {Screen.height}");
        }

        // Update is called once per frame
        void Update()
        {
            /*//키보드 입력값 처리
            if (Input.GetKey("w"))
            {
                Debug.Log("너 지금 W 키를 누르고 있어! 세상에!");
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("너 지금 W 키를 눌렀어! 말도 안 돼!");
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                Debug.Log("W 키에서 손을 떼다니! 감히!");
            }*/

            /*//Input Button
            if (Input.GetButton("Jump"))
            {
                Debug.Log("너 지금 Jump 버튼을 만지고 있는 거야? 제정신이야?");
            }

            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("점프");
            }

            if (Input.GetButtonUp("Jump"))
            {
                Debug.Log("착지");
            }*/

            //Axis
            //left : 0 ~ -1
            //right : 0 ~ 1
            //AxisRaw
            //left : 0, -1
            //right : 0, 1
            /*if (Input.GetButton("Horizontal"))
            {
                *//*float hValue = Input.GetAxis("Horizontal");
                Debug.Log($"Horizontal : {hValue}");*//*

                float hValue = Input.GetAxisRaw("Horizontal");
                Debug.Log($"Horizontal : {hValue}");
            }

            if (Input.GetButton("Vertical"))
            {
                *//*float vValue = Input.GetAxis("Vertical");
                Debug.Log($"Vertical : {vValue}");*//*

                float vValue = Input.GetAxisRaw("Vertical");
                Debug.Log($"Vertical : {vValue}");
            }*/

            //마우스 위치값 얻어오기
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            /*xText.text = "Mouse X : " + ((int)mouseX).ToString();
            yText.text = "Mouse Y : " + ((int)mouseY).ToString();*/

            xText.text = "Mouse X : " + ((int)mouseX).ToString() + "\n" + "Mouse Y : " + ((int)mouseY).ToString();
            xText.rectTransform.anchoredPosition = new Vector2(mouseX+50, mouseY+15);
        }
    }
}