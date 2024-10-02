using UnityEngine;

namespace MyDefence
{
    //�Ǽ��� �ͷ� ������ �����ϴ� Ŭ����
    public class BuildMenu : MonoBehaviour
    {
        #region Variables
        private BuildManager buildManager;

        //�⺻ �ͷ� ������
        //public GameObject basicTurretPrefab;
        //public int basicTurretCost = 100;

        //�̻��� ��ó ������
        //public GameObject missileLauncherPrefab;
        //public int missileLauncherCost = 250;

        //�������Ʈ�� ����
        public TurretBluePrint basicTurret;
        public TurretBluePrint missileLauncher;
        public TurretBluePrint laserBeamer;
        #endregion

        void Start()
        {
            buildManager = BuildManager.Instance;
        }

        public void SelectBasicTurret()
        {
            Debug.Log("�⺻ �ͷ��� ���� �Ͽ����ϴ�!!");

            buildManager.SetTurretToBuild(basicTurret);
        }

        public void SelectMissileLauncher()
        {
            Debug.Log("�̻��� ��ó�� ���� �Ͽ����ϴ�!!");

            buildManager.SetTurretToBuild(missileLauncher);
        }

        public void SelectLaserBeamer()
        {
            Debug.Log("������ ��Ӹ� ���� �Ͽ����ϴ�!!");

            buildManager.SetTurretToBuild(laserBeamer);
        }
    }
}