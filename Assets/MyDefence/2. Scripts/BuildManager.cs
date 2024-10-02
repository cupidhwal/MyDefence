using UnityEngine;

namespace MyDefence
{
    //터렛 건설을 관리하는 클래스
    public class BuildManager : MonoBehaviour
    {
        #region Singleton
        private static BuildManager instance;
        public static BuildManager Instance
        {
            get { return instance; }
        }

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        #endregion

        //필드
        #region Variables
        //타일에 설치할 터렛
        private TurretBluePrint turretToBuild;

        //선택한 터렛이 있는지, 선택하지 않았으면 건설할 수 없음
        public bool CannotBuild => turretToBuild == null;

        //선택한 터렛을 건설한 비용을 가지고 있는지 확인하는 속성
        public bool HaveBuildMoney
        {
            get
            {
                if (turretToBuild == null)
                    return false;

                return PlayerStats.HaveMoney(turretToBuild.cost);
            }
        }

        //타일 UI
        public TileUI tileUI;

        //선택된 타일을 저장하는 변수
        private Tile selectTile;
        #endregion

        private void Start()
        {
            //초기화
            //turretToBuild = basicTurretPrefab;
        }

        //메서드
        #region Methods
        public TurretBluePrint GetTurretToBuild()
        {
            return turretToBuild;
        }

        //매개변수로 받은 터렛 프리팹을 설치할 터렛에 저장
        public void SetTurretToBuild(TurretBluePrint turret)
        {
            turretToBuild = turret;

            DeselectTile();
        }

        //매개변수로 선택한 타일 정보를 얻어온다
        public void SelectTile(Tile tile)
        {
            //같은 타일을 선택하면 HideUI
            if (selectTile == tile)
            {
                DeselectTile();
                return;
            }

            selectTile = tile;

            //건설 선택 초기화
            turretToBuild = null;

            tileUI.ShowTileUI(tile);
        }

        //선택 해제
        public void DeselectTile()
        {
            tileUI.HideTileUI();

            //선택한 타일 초기화하기
            selectTile = null;
        }
        #endregion
    }
}