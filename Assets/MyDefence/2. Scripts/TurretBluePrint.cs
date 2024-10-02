using UnityEngine;

namespace MyDefence
{
    //���� �޴����� ���õǴ� �ͷ��� �Ӽ��� �����ϴ� Ŭ����
    [System.Serializable]
    public class TurretBluePrint
    {
        public GameObject turretPrefab;         //�ͷ� ������
        public int cost;                        //�ͷ� �Ǽ� ���

        public GameObject turretUpgradePrefab;  //�ͷ� ���׷��̵� ������
        public int upgradeCost;                 //�ͷ� ���׷��̵� ���

        public Vector3 offset;                  //�ͷ� �Ǽ� ��ġ ������

        public int GetSellCost()
        {
            return cost/2;
        }
    }
}