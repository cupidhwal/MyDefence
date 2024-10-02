using UnityEngine;

namespace MyDefence
{
    //�ͷ� �Ǽ��� �����ϴ� Ŭ����
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

        //�ʵ�
        #region Variables
        //Ÿ�Ͽ� ��ġ�� �ͷ�
        private TurretBluePrint turretToBuild;

        //������ �ͷ��� �ִ���, �������� �ʾ����� �Ǽ��� �� ����
        public bool CannotBuild => turretToBuild == null;

        //������ �ͷ��� �Ǽ��� ����� ������ �ִ��� Ȯ���ϴ� �Ӽ�
        public bool HaveBuildMoney
        {
            get
            {
                if (turretToBuild == null)
                    return false;

                return PlayerStats.HaveMoney(turretToBuild.cost);
            }
        }

        //Ÿ�� UI
        public TileUI tileUI;

        //���õ� Ÿ���� �����ϴ� ����
        private Tile selectTile;
        #endregion

        private void Start()
        {
            //�ʱ�ȭ
            //turretToBuild = basicTurretPrefab;
        }

        //�޼���
        #region Methods
        public TurretBluePrint GetTurretToBuild()
        {
            return turretToBuild;
        }

        //�Ű������� ���� �ͷ� �������� ��ġ�� �ͷ��� ����
        public void SetTurretToBuild(TurretBluePrint turret)
        {
            turretToBuild = turret;

            DeselectTile();
        }

        //�Ű������� ������ Ÿ�� ������ ���´�
        public void SelectTile(Tile tile)
        {
            //���� Ÿ���� �����ϸ� HideUI
            if (selectTile == tile)
            {
                DeselectTile();
                return;
            }

            selectTile = tile;

            //�Ǽ� ���� �ʱ�ȭ
            turretToBuild = null;

            tileUI.ShowTileUI(tile);
        }

        //���� ����
        public void DeselectTile()
        {
            tileUI.HideTileUI();

            //������ Ÿ�� �ʱ�ȭ�ϱ�
            selectTile = null;
        }
        #endregion
    }
}