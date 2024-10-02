using UnityEngine;

namespace Sample
{
    public class Trap : MonoBehaviour
    {
        private bool m_IsActive;
        public bool IsActive => m_IsActive;

        public void Enable()
        {
            m_IsActive = true;
            Debug.Log("Ʈ�� Ȱ��ȭ");
        }

        public void Disable()
        {
            m_IsActive = false;
            Debug.Log("Ʈ�� ��Ȱ��ȭ");
        }
    }
}