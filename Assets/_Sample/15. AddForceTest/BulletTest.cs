using MyDefence;
using UnityEngine;

namespace Sample
{
    public class BulletTest : MonoBehaviour
    {
        //�ʵ�
        private float fireForce;

        public Rigidbody rb;

        void Start()
        {
            fireForce = 1f;

            MoveByForce();
        }

        //������ �̵�
        public void MoveForward()
        {
            
        }

        public void MoveByForce()
        {
            if (rb != null)
                rb.AddForce(transform.forward * fireForce, ForceMode.Impulse);
        }
    }
}