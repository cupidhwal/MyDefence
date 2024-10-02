using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class EventTest : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("[1] Awake 실행");          // 1회만 호출
        }

        private void OnEnable()
        {
            Debug.Log("[7-1] OnEnable 실행");     // 1회 실행 - 활성화 될 때
        }

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("[2] Start 실행");          // 1회만 호출
        }

        private void FixedUpdate()
        {
            //통상 물리 연산을 담당한다
            Debug.Log("[3] FixedUpdate 실행");    // 1초에 50회 호출
        }

        void Update()
        {
            //통상 키 입력을 담당한다
            Debug.Log("[4] Update 실행");         // 매 프레임마다 호출
        }

        private void LateUpdate()
        {
            //통상 모든 카메라 움직임과 로테이션을 담당한다
            Debug.Log("[5] LateUpdate 실행");     // 매 프레임마다 호출
        }

        private void OnDisable()
        {
            Debug.Log("[7-2] OnDisable 실행");    // 1회 실행 - 비활성화 될 때
        }

        private void OnDestroy()
        {
            Debug.Log("[6] OnDestroy 실행");      // 사라질 때
        }
    }
}