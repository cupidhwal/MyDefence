using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyDefence
{
    public class Missile : Bullet
    {
        //필드
        #region Variables
        public float damageRange = 3.5f;

        public string enemyTag = "Enemy";
        #endregion

        protected override void HitTarget()
        {
            //Hit 효과
            GameObject effectGo = Instantiate(bulletImpactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //damageRange 안에 있는 모든 enemy들 kill (Destroy)
            Explosion();

            //탄환 게임오브젝트 kill (Destroy)
            Destroy(this.gameObject);
        }

        //damageRange 안에 있는 모든 enemy들 kill (Destroy)
        void Explosion()
        {
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, damageRange);

            foreach (var hitCollider in hitColliders)
            {
                IDamagable damagable = hitCollider.transform.GetComponent<IDamagable>();

                if (damagable != null)
                    damagable.TakeDamage(attack);
                    //Destroy(hitCollider.gameObject);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, damageRange);
        }
    }
}