using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOLID
{
    public class UnrefactoredPlayer : MonoBehaviour
    {
        private Vector3 inputVector = Vector3.zero;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();
            Move(inputVector);
        }

        //플레이어 인풋 기능
        private void HandleInput()
        {
            //...
        }

        //플레이어 이동
        private void Move(Vector3 inputVector)
        {
            //...
        }

        //플레이어 사운드
        public void PlayRandomAudioClip()
        {
            //...
        }

        //플레이어 이펙트
        public void PlayEffect()
        {
            //...
        }
        //...
    }
}