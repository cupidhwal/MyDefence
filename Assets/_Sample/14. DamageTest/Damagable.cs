using UnityEngine;

namespace MyDefence
{
    public abstract class Damagable : MonoBehaviour
    {
        public abstract void TakeDamage(float damage);
    }
}