using UnityEngine;

namespace Sample
{
    public class SDoor : MonoBehaviour, ISwitchable
    {
        private bool isActive;
        public bool IsActive => isActive;

        public void Activate()
        {
            isActive = true;
            Debug.Log("���� ������");
        }

        public void Deactivate()
        {
            isActive = false;
            Debug.Log("���� ������");
        }
    }
}