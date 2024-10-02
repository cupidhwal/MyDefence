using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MyDefence
{
    public class TileUI : MonoBehaviour
    {
        #region Variables
        private BuildManager buildManager;

        public GameObject tileUI;

        //���׷��̵� ����
        public Button upgradeButton;
        public TextMeshProUGUI upgradeCostText;

        //�Ǹ� ����
        public TextMeshProUGUI sellCostText;

        //������ Ÿ��
        private Tile targetTile;
        #endregion

        private void Start()
        {
            buildManager = BuildManager.Instance;
        }

        #region Methods
        public void ShowTileUI(Tile tile)
        {
            //���õ� Ÿ�� ����
            targetTile = tile;

            //�ͷ��� ��ġ�� ��ġ���� �����ش�
            this.transform.position = targetTile.GetBuildPosition();

            //���׷��̵� ���� ǥ��
            if (targetTile.IsUpgrade == true)
            {
                upgradeButton.interactable = false;
                upgradeCostText.text = "DONE";
            }

            else
            {
                upgradeButton.interactable = true;
                upgradeCostText.text = targetTile.bluePrint.upgradeCost.ToString() + " G";
            }

            //�Ǹ� ���� ǥ��
            sellCostText.text = (targetTile.bluePrint.GetSellCost()).ToString() + " G";

            tileUI.SetActive(true);
        }

        public void HideTileUI()
        {
            tileUI.SetActive(false);

            //���õ� Ÿ�� �ʱ�ȭ
            targetTile = null;
        }

        public void Upgrade()
        {
            //targetTile�� �ͷ��� ���׷��̵��Ѵ�
            targetTile.UpgradeTurret();

            //���׷��̵带 �Ϸ��ߴٸ� UI ���߱�
            buildManager.DeselectTile();
        }

        public void Sell()
        {
            //targetTile�� �ͷ��� �Ǹ��Ѵ�.
            targetTile.SellTurret();

            //���׷��̵带 �Ϸ��ߴٸ� UI ���߱�
            buildManager.DeselectTile();
        }
        #endregion
    }
}