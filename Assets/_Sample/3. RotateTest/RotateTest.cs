using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Sample
{
    public class RotateTest : MonoBehaviour
    {
        //필드
        //float x = 0f;

        //회전 속도
        private float turnSpeed = 1f;

        //타겟
        public Transform target;

        // Start is called before the first frame update
        void Start()
        {
            //y축 회전
            //this.transform.rotation = Quaternion.Euler(0, 90f, 0);
            //x축 회전
            //this.transform.rotation = Quaternion.Euler(90f, 0, 0);
            //z축 회전
            //this.transform.rotation = Quaternion.Euler(0, 0, 90f);
        }

        // Update is called once per frame
        void Update()
        {
            /*x += 1;
            this.transform.rotation = Quaternion.Euler(0, x, 0);*/

            //Rotate
            //this.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);

            //RotateAround
            //this.transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * turnSpeed);

            //방향 구하기
            Vector3 targetDirection = (target.transform.position - transform.position).normalized;

            //상하 회전은 필요 없음
            targetDirection.y = 0;

            //방향 벡터로부터 회전값 구하기
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        }
    }
}

/*
Lerp(a, b, t)
a = 0;
b = 10;
c = Lerp(a, b, 0.1) // 1
c = Lerp(a, b, 0.2) // 2
...
c = Lerp(a, b, 1)   // 10

//
Lerp(a, b, t)
a = 0;
b = 10;
a = Lerp(a, b, 0.1) // 1
a = Lerp(a, b, 0.1) // 1.9
 */