using UnityEngine;
using UnityEngine.UI;

namespace MyDefence
{
    //Enemy�� �����ϴ� Ŭ����
    public class Enemy : MonoBehaviour, IDamagable
    {
        //�ʵ�
        #region Variable
        private float health;    //ü��
        [SerializeField]private float startHealth = 100f;

        private bool isDead = false;

        public GameObject deathEffectPrefab;

        //���� �ݾ�
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
            //Debug.Log($"���� ü��: {health}");

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
