using UnityEngine;

namespace MyDefence
{
    //건설할 터렛 선택을 관리하는 클래스
    public class BuildMenu : MonoBehaviour
    {
        #region Variables
        private BuildManager buildManager;

        //기본 터렛 프리팹
        //public GameObject basicTurretPrefab;
        //public int basicTurretCost = 100;

        //미사일 런처 프리팹
        //public GameObject missileLauncherPrefab;
        //public int missileLauncherCost = 250;

        //블루프린트로 변경
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
            Debug.Log("기본 터렛을 선택 하였습니다!!");

            buildManager.SetTurretToBuild(basicTurret);
        }

        public void SelectMissileLauncher()
        {
            Debug.Log("미사일 런처를 선택 하였습니다!!");

            buildManager.SetTurretToBuild(missileLauncher);
        }

        public void SelectLaserBeamer()
        {
            Debug.Log("레이저 비머를 선택 하였습니다!!");

            buildManager.SetTurretToBuild(laserBeamer);
        }
    }
}