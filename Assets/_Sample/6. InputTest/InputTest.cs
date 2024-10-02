using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Sample
{
    public class InputTest : MonoBehaviour
    {
        //�ʵ�
        public TextMeshProUGUI xText;
        public TextMeshProUGUI yText;

        // Start is called before the first frame update
        void Start()
        {
            //��ũ���� ũ��
            Debug.Log($"Screen Width : {Screen.width}, Screen Height : {Screen.height}");
        }

        // Update is called once per frame
        void Update()
        {
            /*//Ű���� �Է°� ó��
            if (Input.GetKey("w"))
            {
                Debug.Log("�� ���� W Ű�� ������ �־�! ����!");
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("�� ���� W Ű�� ������! ���� �� ��!");
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                Debug.Log("W Ű���� ���� ���ٴ�! ����!");
            }*/

            /*//Input Button
            if (Input.GetButton("Jump"))
            {
                Debug.Log("�� ���� Jump ��ư�� ������ �ִ� �ž�? �������̾�?");
            }

            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("����");
            }

            if (Input.GetButtonUp("Jump"))
            {
                Debug.Log("����");
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

            //���콺 ��ġ�� ������
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            /*xText.text = "Mouse X : " + ((int)mouseX).ToString();
            yText.text = "Mouse Y : " + ((int)mouseY).ToString();*/

            xText.text = "Mouse X : " + ((int)mouseX).ToString() + "\n" + "Mouse Y : " + ((int)mouseY).ToString();
            xText.rectTransform.anchoredPosition = new Vector2(mouseX+50, mouseY+15);
        }
    }
}