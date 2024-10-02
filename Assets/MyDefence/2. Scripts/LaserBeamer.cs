using UnityEngine;

namespace MyDefence
{
    public class LaserBeamer : Turret
    {
        #region Variables
        //레이저 빔
        private LineRenderer lineRenderer;

        //레이저 빔 이펙트
        public ParticleSystem impactEffect;

        //레이저 이펙트 라이트
        public Light impactLight;

        //레이저 데미지
        [SerializeField] private float laserDamage = 30f;
        //레이저 감속 비율
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
            /*//0.5초마다 타겟 찾기 실행
            if (countdown <= 0f)
            {
                //타이머 실행문
                UpdateTarget();

                //타이머 초기화
                countdown = serachTimer;
            }
            countdown -= Time.deltaTime;*/

            //타겟을 찾지 못했으면
            if (target == null)
            {
                LaserDisable();

                return;
            }

            //타겟을 향해 총구를 회전
            LockOn();

            //레이저 쏘기
            Laser();
        }

        void Laser()
        {
            //초당 30 데미지
            float damage = laserDamage * Time.deltaTime;
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
                enemy.TakeDamage(damage);

            //타격 중 적 이동속도 40% 감소
            EnemyMove enemyMove = target.GetComponent<EnemyMove>();
            if (enemyMove != null)
                enemyMove.Slow(slowRate);

            LaserEnable();

            //라인렌더러 그리기 - 시작지점, 끝지점 지정
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, target.position);

            //offset 계산


            //레이저 이펙트 회전
            Vector3 targetRotation = firePoint.position - impactEffect.transform.position;
            impactEffect.transform.rotation = Quaternion.LookRotation(targetRotation);

            //레이저 이펙트 효과 그리기
            impactEffect.transform.position = target.position + targetRotation.normalized * 0.5f;
        }

        void LaserEnable()
        {
            //레이저 발사
            if (lineRenderer.enabled == false)
            {
                lineRenderer.enabled = true;
                impactEffect.Play();
                impactLight.enabled = true;
            }
        }

        void LaserDisable()
        {
            //레이저 중지
            if (lineRenderer.enabled == true)
            {
                lineRenderer.enabled = false;
                impactEffect.Stop();
                impactLight.enabled = false;
            }
        }
    }
}