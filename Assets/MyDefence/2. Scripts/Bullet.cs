using UnityEngine;

namespace MyDefence
{
    public class Bullet : MonoBehaviour
    {
        //�ʵ�
        #region Variable
        //bullet�� �̵��ؼ� hit �ϴ� target
        protected Transform target;

        //bullet �̵� �ӵ�
        public float moveSpeed = 70f;

        //impact ����Ʈ
        public GameObject bulletImpactPrefab;

        //Bullet ���ݷ�
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

            //�̵��ϱ�
            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = Time.deltaTime * moveSpeed;
            if (dir.magnitude < distanceThisFrame)
            {
                //Hit�� ����
                HitTarget();
                return;
            }
            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);

            //Ÿ���� �ٶ󺻴�
            transform.LookAt(target);
        }

        //Ÿ���� ����
        protected virtual void HitTarget()
        {
            //Hit ȿ��
            GameObject effectGo = Instantiate(bulletImpactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //Ÿ�ٿ� �������� �ش�
            Damage(target);

            //źȯ ���ӿ�����Ʈ kill (Destroy)
            Destroy(this.gameObject);
        }

        protected void Damage(Transform target)
        {
            //attack ��ŭ Ÿ�ٿ��� �������� �ش�
            //enemy�� health�� attack��ŭ �����Ѵ�
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