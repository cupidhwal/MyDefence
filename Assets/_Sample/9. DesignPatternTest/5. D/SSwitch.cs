using UnityEngine;

namespace Sample
{
    public class SSwitch : MonoBehaviour
    {
        //public SDoor sDoor;
        public ISwitchable client;
        public Transform clientTrans;

        private void Start()
        {
            client = clientTrans.GetComponent<ISwitchable>();
            Debug.Log(client);
        }

        //�ѹ� ȣ���ϸ� ���� ������ �ٽ� ȣ���ϸ� ���� ������
        public void Toggle()
        {
            if (client.IsActive)
            {
                client.Deactivate();
            }
            else
            {
                client.Activate();
            }
        }
    }
}