using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyDefence
{
    public class moveEnemy : MonoBehaviour
    {
        private float speed = 5.0f;
        private int currentWaypointIndex = 0;

        private Vector3 moveDirection;
        public GameObject[] waypoints;
        private GameObject end;

        private void Start()
        {
            end = GameObject.FindGameObjectWithTag("Finish");
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (waypoints.Length == 0) return;

            Transform targetWaypoint;

            if (currentWaypointIndex < waypoints.Length)
                targetWaypoint = waypoints[currentWaypointIndex].transform;

            else
                targetWaypoint = end.transform;

            moveDirection = (targetWaypoint.position - transform.position).normalized;

            transform.Translate(moveDirection * speed * Time.fixedDeltaTime, Space.World);

            // ��������Ʈ�� �����ϸ� ���� ��������Ʈ�� �̵�
            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                // ������ ��������Ʈ�� �����ߴ��� Ȯ��
                if (currentWaypointIndex < waypoints.Length)
                {
                    Debug.Log("����!!");
                    currentWaypointIndex++;
                }
            }
        }

        /*private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Finish"))
            {
                Debug.Log("���� ����!!");
                Destroy(gameObject);
            }
        }*/
    }
}