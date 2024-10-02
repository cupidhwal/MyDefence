using UnityEngine;

namespace MyDefence
{
    public class Mop : MonoBehaviour, IDamagable
    {
        //필드
        #region Variable
        private float health;    //체력
        [SerializeField] private float startHealth = 100f;

        private EnemyMove enemyMove;    //

        public GameObject deathEffectPrefab;

        //보상 금액
        [SerializeField] private int rewardGold;
        #endregion

        void Start()
        {
            enemyMove = GetComponent<EnemyMove>();

            health = startHealth;
        }

        private void Update()
        {
            //이동
            //enemyMove.Move();
        }

        private void OnDisable()
        {

        }

        public void TakeDamage(float atk)
        {
            health -= atk;
            Debug.Log($"현재 체력: {health}");

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