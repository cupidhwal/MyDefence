using UnityEngine;

namespace Sample
{
    public class Switch : MonoBehaviour
    {
        public Door door;
        public bool isActivated;

        //�ѹ� ȣ���ϸ� ���� ������ �ٽ� ȣ���ϸ� ���� ������
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