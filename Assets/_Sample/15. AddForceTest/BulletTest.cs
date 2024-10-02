using MyDefence;
using UnityEngine;

namespace Sample
{
    public class BulletTest : MonoBehaviour
    {
        //필드
        private float fireForce;

        public Rigidbody rb;

        void Start()
        {
            fireForce = 1f;

            MoveByForce();
        }

        //앞으로 이동
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