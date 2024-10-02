using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Sample
{
    public class MoveForward : MonoBehaviour
    {
        private Transform tf;    //Transform 참조 변수

        // Start is called before the first frame update
        void Start()
        {
            tf = GetComponent<Transform>();  //변수 초기화
        }

        private void FixedUpdate()
        {
            tf.position += Vector3.forward;
        }
    }
}