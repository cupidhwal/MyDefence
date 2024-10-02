using UnityEngine;

namespace SOLID
{
    public class RoadVehicle : IMovable, ITurnable
    {
        public void GoForward()
        {
            //도로 위의 탈것이 앞으로 간다
        }

        public void GoBack()
        {
            //도로 위의 탈것이 후진한다        
        }

        public void TurnLeft()
        {
            //도로 위의 탈것이 좌회전
        }

        public void TurnRight()
        {
            //도로 위의 탈것이 우회전
        }
    }
}