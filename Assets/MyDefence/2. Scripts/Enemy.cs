using UnityEngine;
using UnityEngine.UI;

namespace MyDefence
{
    //Enemy를 관리하는 클래스
    public class Enemy : MonoBehaviour, IDamagable
    {
        //필드
        #region Variable
        private float health;    //체력
        [SerializeField]private float startHealth = 100f;

        private bool isDead = false;

        public GameObject deathEffectPrefab;

        //보상 금액
        [SerializeField]private int rewardGold = 50;

        public Image healthbar;
        #endregion

        void Start()
        {
            health = startHealth;
        }

        public void TakeDamage(float atk)
        {
            health -= atk;
            //Debug.Log($"현재 체력: {health}");

            healthbar.fillAmount = health / startHealth;

            if (health <= 0 && isDead == false)
                Die();
        }

        /*private bool DeathCheck()
        {
            if (health <= 0)
            {
                health = Mathf.Infinity;
                return true;
            }

            else return false;
        }*/

        private void Die()
        {
            isDead = true;

            Destroy(this.gameObject);

            GameObject effectGo = Instantiate(deathEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            GameManager.enemyAlive--;

            PlayerStats.EarnMoney(rewardGold);
        }
    }
}
