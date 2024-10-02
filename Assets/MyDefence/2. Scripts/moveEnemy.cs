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

            // 웨이포인트에 도착하면 다음 웨이포인트로 이동
            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                // 마지막 웨이포인트에 도달했는지 확인
                if (currentWaypointIndex < waypoints.Length)
                {
                    Debug.Log("도착!!");
                    currentWaypointIndex++;
                }
            }
        }

        /*private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Finish"))
            {
                Debug.Log("종점 도착!!");
                Destroy(gameObject);
            }
        }*/
    }
}