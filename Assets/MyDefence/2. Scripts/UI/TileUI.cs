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

        //업그레이드 가격
        public Button upgradeButton;
        public TextMeshProUGUI upgradeCostText;

        //판매 가격
        public TextMeshProUGUI sellCostText;

        //선택한 타일
        private Tile targetTile;
        #endregion

        private void Start()
        {
            buildManager = BuildManager.Instance;
        }

        #region Methods
        public void ShowTileUI(Tile tile)
        {
            //선택된 타일 저장
            targetTile = tile;

            //터렛이 설치된 위치에서 보여준다
            this.transform.position = targetTile.GetBuildPosition();

            //업그레이드 가격 표시
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

            //판매 가격 표시
            sellCostText.text = (targetTile.bluePrint.GetSellCost()).ToString() + " G";

            tileUI.SetActive(true);
        }

        public void HideTileUI()
        {
            tileUI.SetActive(false);

            //선택된 타일 초기화
            targetTile = null;
        }

        public void Upgrade()
        {
            //targetTile의 터렛을 업그레이드한다
            targetTile.UpgradeTurret();

            //업그레이드를 완료했다면 UI 감추기
            buildManager.DeselectTile();
        }

        public void Sell()
        {
            //targetTile의 터렛을 판매한다.
            targetTile.SellTurret();

            //업그레이드를 완료했다면 UI 감추기
            buildManager.DeselectTile();
        }
        #endregion
    }
}