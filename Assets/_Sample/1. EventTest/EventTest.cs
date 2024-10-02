using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class EventTest : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("[1] Awake ����");          // 1ȸ�� ȣ��
        }

        private void OnEnable()
        {
            Debug.Log("[7-1] OnEnable ����");     // 1ȸ ���� - Ȱ��ȭ �� ��
        }

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("[2] Start ����");          // 1ȸ�� ȣ��
        }

        private void FixedUpdate()
        {
            //��� ���� ������ ����Ѵ�
            Debug.Log("[3] FixedUpdate ����");    // 1�ʿ� 50ȸ ȣ��
        }

        void Update()
        {
            //��� Ű �Է��� ����Ѵ�
            Debug.Log("[4] Update ����");         // �� �����Ӹ��� ȣ��
        }

        private void LateUpdate()
        {
            //��� ��� ī�޶� �����Ӱ� �����̼��� ����Ѵ�
            Debug.Log("[5] LateUpdate ����");     // �� �����Ӹ��� ȣ��
        }

        private void OnDisable()
        {
            Debug.Log("[7-2] OnDisable ����");    // 1ȸ ���� - ��Ȱ��ȭ �� ��
        }

        private void OnDestroy()
        {
            Debug.Log("[6] OnDestroy ����");      // ����� ��
        }
    }
}