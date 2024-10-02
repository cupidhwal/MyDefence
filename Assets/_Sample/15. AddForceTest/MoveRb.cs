using UnityEngine;

namespace Sample
{
    public class MoveRb : MonoBehaviour
    {
        private Rigidbody rb;
        public float moveSpeed = 1.0f;
        public float moveForce = 10;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();

            rb.AddForce(this.transform.forward * moveForce, ForceMode.Force);
        }

        private void FixedUpdate()
        {
            //Kinematic 이동
            //rb.MovePosition(this.transform.position + Vector3.forward * Time.fixedDeltaTime * moveSpeed);

            //Dynamic 이동
            //rb.AddForce(this.transform.forward * moveForce, ForceMode.Impulse);
        }
    }
}

/*
3D 충돌체 (충돌 오브젝트)
. 정적 충돌체 : 움직이지 않는 충돌체
- Static : 벽, 건물, 큰 바위, 

. 동적 충돌체 : 움직이는 충돌체 - Rigidbody (오브젝트의 움직임을 물리로 제어)
- Kinematic : 외부에서 오는 물리력을 무시, 운동학, 이동하는 발판, 문
- Dynamic : 그외 물리력으로 제외되는 오브젝트

충돌체크
: 두 오브젝트가 모두 충돌체(Collider)를 가지고 있어야 한다.
: 행동의 주체는 Rigidbody를 가지고 있어야 한다. 즉, 이동하는 녀석이 Rigidbody를 가지고 있어야 충돌 판정이 가능하다.
: 이동하는 Kinematic은 Dynamic과 충돌체크 가능



2D 충돌체 (충돌 오브젝트)
. 정적 충돌체 : 움직이지 않는 충돌체
- Static : 벽, 건물, 큰 바위, 

. 동적 충돌체 : 움직이는 충돌체 - Rigidbody (오브젝트의 움직임을 물리로 제어)
- Static : Bodytype에서 static 설정
- Kinematic : 외부에서 오는 물리력을 무시, 운동학, 이동하는 발판, 문
- Dynamic : 그외 물리력으로 제외되는 오브젝트

충돌체크
: 두 오브젝트가 모두 충돌체(Collider)를 가지고 있어야 한다.
: 행동의 주체는 Rigidbody를 가지고 있어야 한다. 즉, 이동하는 녀석이 Rigidbody를 가지고 있어야 충돌 판정이 가능하다.
: 이동하는 Kinematic은 Dynamic과 충돌체크 가능



//
AddForce : ForceMode 4가지

ForceMode.Force (연속, 질량 고려)
- 바람, 자기력처럼 연속적으로 힘을 주는 것
- 짧은 시간에 발생하는 힘

ForceMode.Acceleration (연속, 질량 무시)
- 지구의 중력
- 질량에 상관 없이 일정한 가속을 가한다

ForceMode.Impulse (순간, 질량 고려)
- 폭발, 타격
- 순간적으로 작용하는 힘

ForceMode.VelocityChange (순간, 질량 무시)
- 질량을 무시하고 직접적으로 속도의 변화를 주는 힘
 */