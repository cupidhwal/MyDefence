using UnityEngine;

namespace MyDefence
{
    public class LaserBeamer : Turret
    {
        #region Variables
        //������ ��
        private LineRenderer lineRenderer;

        //������ �� ����Ʈ
        public ParticleSystem impactEffect;

        //������ ����Ʈ ����Ʈ
        public Light impactLight;

        //������ ������
        [SerializeField] private float laserDamage = 30f;
        //������ ���� ����
        [SerializeField] private float slowRate = 0.4f;
        #endregion

        protected override void Start()
        {
            base.Start();

            lineRenderer = GetComponent<LineRenderer>();
            LaserDisable();
        }

        private void Update()
        {
            /*//0.5�ʸ��� Ÿ�� ã�� ����
            if (countdown <= 0f)
            {
                //Ÿ�̸� ���๮
                UpdateTarget();

                //Ÿ�̸� �ʱ�ȭ
                countdown = serachTimer;
            }
            countdown -= Time.deltaTime;*/

            //Ÿ���� ã�� ��������
            if (target == null)
            {
                LaserDisable();

                return;
            }

            //Ÿ���� ���� �ѱ��� ȸ��
            LockOn();

            //������ ���
            Laser();
        }

        void Laser()
        {
            //�ʴ� 30 ������
            float damage = laserDamage * Time.deltaTime;
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
                enemy.TakeDamage(damage);

            //Ÿ�� �� �� �̵��ӵ� 40% ����
            EnemyMove enemyMove = target.GetComponent<EnemyMove>();
            if (enemyMove != null)
                enemyMove.Slow(slowRate);

            LaserEnable();

            //���η����� �׸��� - ��������, ������ ����
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, target.position);

            //offset ���


            //������ ����Ʈ ȸ��
            Vector3 targetRotation = firePoint.position - impactEffect.transform.position;
            impactEffect.transform.rotation = Quaternion.LookRotation(targetRotation);

            //������ ����Ʈ ȿ�� �׸���
            impactEffect.transform.position = target.position + targetRotation.normalized * 0.5f;
        }

        void LaserEnable()
        {
            //������ �߻�
            if (lineRenderer.enabled == false)
            {
                lineRenderer.enabled = true;
                impactEffect.Play();
                impactLight.enabled = true;
            }
        }

        void LaserDisable()
        {
            //������ ����
            if (lineRenderer.enabled == true)
            {
                lineRenderer.enabled = false;
                impactEffect.Stop();
                impactLight.enabled = false;
            }
        }
    }
}