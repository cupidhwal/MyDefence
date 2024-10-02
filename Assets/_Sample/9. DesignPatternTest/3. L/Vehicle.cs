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
            //앞으로 직진
        }

        public virtual void GoBack()
        {
            //뒤로 후진
        }

        public virtual void TurnLeft()
        {
            //좌회전
        }

        public virtual void TurnRight()
        {
            //우회전
        }
    }

    //Vehicle을 상속받는 Car
    public class Car : Vehicle
    {
        public override void GoForward()
        {
            //자동차가 앞으로 이동한다
        }

        public override void GoBack()
        {
            //자동차가 뒤로 후진한다
        }

        public override void TurnLeft()
        {
            //자동차가 좌회전한다
        }

        public override void TurnRight()
        {
            //자동차가 우회전한다
        }
    }

    //Vehicle을 상속받는 Train
    public class Train : Vehicle
    {
        public override void GoForward()
        {
            //기차가 앞으로 이동한다
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