using UnityEngine;

namespace MyDefence
{
    //Wave �����͸� �����ϴ� Ŭ����
    [System.Serializable]
    public class Wave
    {
        public GameObject enemyPrefab;      //�����Ǵ� Enemy ������
        public int count;                   //�����Ǵ� Enemy ��
        public float delayTime;             //���� ���� �ð�

        //...
    }
}