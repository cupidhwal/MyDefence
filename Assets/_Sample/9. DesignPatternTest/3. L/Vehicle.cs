using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOLID
{
    public class Vehicle
    {
        public float speed;
        public Vector3 direction;

        public virtual void GoForward()
        {
            //������ ����
        }

        public virtual void GoBack()
        {
            //�ڷ� ����
        }

        public virtual void TurnLeft()
        {
            //��ȸ��
        }

        public virtual void TurnRight()
        {
            //��ȸ��
        }
    }

    //Vehicle�� ��ӹ޴� Car
    public class Car : Vehicle
    {
        public override void GoForward()
        {
            //�ڵ����� ������ �̵��Ѵ�
        }

        public override void GoBack()
        {
            //�ڵ����� �ڷ� �����Ѵ�
        }

        public override void TurnLeft()
        {
            //�ڵ����� ��ȸ���Ѵ�
        }

        public override void TurnRight()
        {
            //�ڵ����� ��ȸ���Ѵ�
        }
    }

    //Vehicle�� ��ӹ޴� Train
    public class Train : Vehicle
    {
        public override void GoForward()
        {
            //������ ������ �̵��Ѵ�
        }

        public override void GoBack()
        {
        }

        public override void TurnLeft()
        {
            
        }

        public override void TurnRight()
        {
            
        }
    }
}