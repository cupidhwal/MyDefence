using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Sample
{
    public class RotateTest : MonoBehaviour
    {
        //�ʵ�
        //float x = 0f;

        //ȸ�� �ӵ�
        private float turnSpeed = 1f;

        //Ÿ��
        public Transform target;

        // Start is called before the first frame update
        void Start()
        {
            //y�� ȸ��
            //this.transform.rotation = Quaternion.Euler(0, 90f, 0);
            //x�� ȸ��
            //this.transform.rotation = Quaternion.Euler(90f, 0, 0);
            //z�� ȸ��
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

            //���� ���ϱ�
            Vector3 targetDirection = (target.transform.position - transform.position).normalized;

            //���� ȸ���� �ʿ� ����
            targetDirection.y = 0;

            //���� ���ͷκ��� ȸ���� ���ϱ�
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