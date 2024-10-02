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

        //�÷��̾� ��ǲ ���
        private void HandleInput()
        {
            //...
        }

        //�÷��̾� �̵�
        private void Move(Vector3 inputVector)
        {
            //...
        }

        //�÷��̾� ����
        public void PlayRandomAudioClip()
        {
            //...
        }

        //�÷��̾� ����Ʈ
        public void PlayEffect()
        {
            //...
        }
        //...
    }
}