using UnityEngine;

namespace MyDefence
{
    public class Bullet : MonoBehaviour
    {
        //필드
        #region Variable
        //bullet이 이동해서 hit 하는 target
        protected Transform target;

        //bullet 이동 속도
        public float moveSpeed = 70f;

        //impact 이펙트
        public GameObject bulletImpactPrefab;

        //Bullet 공격력
        protected float attack;
        [SerializeField]protected float startAttack = 50;
        #endregion

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        // Start is called before the first frame update
        void Start()
        {
            attack = startAttack;
        }

        // Update is called once per frame
        void Update()
        {
            if (target == null)
            {
                Destroy(this.gameObject);
                return;
            }

            //이동하기
            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = Time.deltaTime * moveSpeed;
            if (dir.magnitude < distanceThisFrame)
            {
                //Hit로 판정
                HitTarget();
                return;
            }
            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);

            //타겟을 바라본다
            transform.LookAt(target);
        }

        //타겟을 맞춤
        protected virtual void HitTarget()
        {
            //Hit 효과
            GameObject effectGo = Instantiate(bulletImpactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //타겟에 데미지를 준다
            Damage(target);

            //탄환 게임오브젝트 kill (Destroy)
            Destroy(this.gameObject);
        }

        protected void Damage(Transform target)
        {
            //attack 만큼 타겟에게 데미지를 준다
            //enemy의 health를 attack만큼 감산한다
            /*Enemy enemy = target.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(attack);
            }

            //Test
            Monster monster = target.GetComponent<Monster>();

            if (monster != null)
            {
                monster.TakeDamage(attack);
            }

            Mop mop = target.GetComponent<Mop>();

            if (mop != null)
            {
                mop.TakeDamage(attack);
            }*/

            IDamagable damagable = target.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(attack);
            }
        }
    }
}