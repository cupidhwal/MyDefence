using UnityEngine;

namespace Sample
{
    public class ExplodingBarrel : MonoBehaviour, IDamagable, IExplodable
    {
        public float Mass { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public float ExplosiveForce { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public float FuseDelay { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Defence { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Die()
        {
            throw new System.NotImplementedException();
        }

        public void Explode()
        {
            throw new System.NotImplementedException();
        }

        public void RestoreHealth()
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage()
        {
            throw new System.NotImplementedException();
        }
    }
}