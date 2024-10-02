using UnityEngine;

namespace MyDefence
{
    public class Mop : MonoBehaviour, IDamagable
    {
        //�ʵ�
        #region Variable
        private float health;    //ü��
        [SerializeField] private float startHealth = 100f;

        private EnemyMove enemyMove;    //

        public GameObject deathEffectPrefab;

        //���� �ݾ�
        [SerializeField] private int rewardGold;
        #endregion

        void Start()
        {
            enemyMove = GetComponent<EnemyMove>();

            health = startHealth;
        }

        private void Update()
        {
            //�̵�
            //enemyMove.Move();
        }

        private void OnDisable()
        {

        }

        public void TakeDamage(float atk)
        {
            health -= atk;
            Debug.Log($"���� ü��: {health}");

            if (health <= 0)
                Die();
        }

        private void Die()
        {
            Destroy(this.gameObject);

            GameObject effectGo = Instantiate(deathEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            PlayerStats.EarnMoney(rewardGold);
        }
    }
}