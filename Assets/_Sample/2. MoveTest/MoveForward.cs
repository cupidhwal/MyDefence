using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Sample
{
    public class MoveForward : MonoBehaviour
    {
        private Transform tf;    //Transform ���� ����

        // Start is called before the first frame update
        void Start()
        {
            tf = GetComponent<Transform>();  //���� �ʱ�ȭ
        }

        private void FixedUpdate()
        {
            tf.position += Vector3.forward;
        }
    }
}