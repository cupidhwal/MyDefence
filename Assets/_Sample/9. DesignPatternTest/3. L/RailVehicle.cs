using UnityEngine;

namespace SOLID
{
    public class RailVehicle : IMovable
    {
        public void GoForward()
        {
            //철도 탈것이 앞으로 전진한다
        }

        public void GoBack()
        {
            //철도 탈것이 뒤로 후진한다
        }
    }

    public class korTrain : RailVehicle
    {

    }
}