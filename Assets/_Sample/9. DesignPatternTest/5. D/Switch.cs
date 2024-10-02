using UnityEngine;

namespace Sample
{
    public class Switch : MonoBehaviour
    {
        public Door door;
        public bool isActivated;

        //한번 호출하면 문이 열리고 다시 호출하면 문이 닫힌다
        public void Toggle()
        {
            if (isActivated)
            {
                isActivated = false;
                door.Close();
            }
            else
            {
                isActivated = true;
                door.Open();
            }
        }
    }
}