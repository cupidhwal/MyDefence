using UnityEngine;

namespace MyDefence
{
    public class EnemyMove : MonoBehaviour
    {
        //�ʵ�
        #region Variable
        private float speed;            //�̵��ӵ�
        [SerializeField]private float startSpeed = 3f;  //�ʱ� �̵��ӵ�
        private Transform target;       //�̵��� ��ǥ����

        private int wayPointIndex = 0;  //wayPoints �迭�� �����ϴ� �ε���

        //private bool isPaid = false;
        //public Transform startPoint;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            //�ʱ�ȭ
            speed = startSpeed;

            //ù��° ��ǥ���� ����
            wayPointIndex = 0;
            target = WayPoints.points[wayPointIndex];
        }

        private void Update()
        {
            Move();

            speed = startSpeed;
        }

        //�̵�
        public void Move()
        {
            //�̵� :����(dir), Time.deltatiem, speed
            Vector3 dir = target.position - this.transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * speed);

            //��������
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance < 0.2f)
            {
                SetNextTarget();
            }
        }

        //���� ��ǥ ���� ����
        void SetNextTarget()
        {
            if (wayPointIndex == WayPoints.points.Length - 1)
            {
                Arrive();
                return;
            }

            wayPointIndex++;
            target = WayPoints.points[wayPointIndex];
        }

        //��ǥ���� ���� ó��
        void Arrive()
        {
            //Debug.Log("���� ����");
            PlayerStats.UseLife(1);

            //���� ������Ʈ kill
            Destroy(this.gameObject);
            //
            //Debug.Log("����");
            //isPaid = true;
        }

        public void Slow(float rate)
        {
            speed = startSpeed * (1.0f - rate);
        }
    }
}