using UnityEngine;
using UnityEngine.EventSystems;

namespace MyDefence
{
    public class Tile : MonoBehaviour
    {
        #region Variables
        //마우스가 위에 있을 때의 타일 컬러값
        public Color hoverColor;
        public Material hoverMaterial;

        //돈이 부족할 때의 컬러
        public Color notEnoughColor;

        //맵 타일의 기본 컬러
        private Color startColor;
        private Material startMaterial;

        //타일에 설치된 터렛 게임 오브젝트 객체
        private GameObject turret;

        //현재 선택된 터렛 bluePrint(prefab, cost, ...)
        public TurretBluePrint bluePrint;

        //빌드매니저
        private BuildManager buildManager;

        //타일에 뭔가가 설치되었는지 확인하는 플래그
        //private bool isBuild = false;

        //렌더러 인스턴스
        private Renderer rend;

        //빌드 이펙트 프리팹
        public GameObject buildEffectPrefab;
        public GameObject sellEffectPrefab;

        //터렛 업그레이드 여부
        public bool IsUpgrade { get; private set; }
        #endregion

        private void Start()
        {
            //초기화
            buildManager = BuildManager.Instance;

            rend = GetComponent<Renderer>();

            //startColor = rend.material.color
            startMaterial = rend.material;

            rend.enabled = false;

            IsUpgrade = false;
        }

        private void OnMouseEnter()
        {
            //마우스 포인터가 UI 위에 있으면 
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (buildManager.CannotBuild)
                return;

            rend.enabled = true;
            //rend.material.color = hoverColor;
            rend.material = hoverMaterial;

            if (buildManager.HaveBuildMoney == false)
            {
                rend.material.color = notEnoughColor;
            }
        }

        private void OnMouseOver()
        {
            if (buildManager.HaveBuildMoney == true)
                rend.material = hoverMaterial;

            else
                rend.material.color = notEnoughColor;
        }

        private void OnMouseDown()
        {
            //마우스 포인터가 UI 위에 있으면 
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (turret != null)
            {
                //선택한 타일의 정보를 넘겨준다
                buildManager.SelectTile(this);
                return;
            }

            BuildTurret();
        }

        private void BuildTurret()
        {
            //설치할 터렛의 속성값 가져오기 (터렛 프리팹, 건설 비용, 업그레이드 프리팹, ...)
            bluePrint = buildManager.GetTurretToBuild();

            if (bluePrint == null)
                return;

            //돈을 지불한다 100, 250
            //Debug.Log($"터렛 건설비용: {bluePrint.cost}");
            if (PlayerStats.SpendMoney(bluePrint.cost))
            {
                //터렛 건설 이펙트
                GameObject effectGo = Instantiate(buildEffectPrefab, GetBuildPosition(), Quaternion.Euler(-90f, 0f, 0f));
                Destroy(effectGo, 2f);

                //터렛 건설
                turret = Instantiate(bluePrint.turretPrefab, GetBuildPosition(), Quaternion.identity);

                //Debug.Log($"건설하고 남은 돈: {PlayerStats.Money}");
            }
        }

        public void UpgradeTurret()
        {
            if (bluePrint == null) return;

            //업그레이드 터렛을 생성
            if (PlayerStats.SpendMoney(bluePrint.upgradeCost))
            {
                //기존 터렛을 파괴하고
                Destroy(turret);

                IsUpgrade = true;

                //터렛 건설 이펙트
                GameObject effectGo = Instantiate(buildEffectPrefab, GetBuildPosition(), Quaternion.Euler(-90f, 0f, 0f));
                Destroy(effectGo, 2f);

                //업그레이드 터렛 건설
                turret = Instantiate(bluePrint.turretUpgradePrefab, GetBuildPosition(), Quaternion.identity);
            }
        }

        public void SellTurret()
        {
            if (bluePrint == null) return;

            int sellMoney = bluePrint.GetSellCost();

            //터렛 파괴
            Destroy(turret);

            //터렛 판매 이펙트
            GameObject effectGo = Instantiate(sellEffectPrefab, GetBuildPosition(), Quaternion.Euler(-90f, 0f, 0f));
            Destroy(effectGo, 2f);

            //건설 관련 변수 초기화
            turret = null;
            bluePrint = null;
            IsUpgrade = false;

            //판매 가격 벌기
            PlayerStats.EarnMoney(sellMoney);
        }

        //터렛 설치 위치
        public Vector3 GetBuildPosition()
        {
            return this.transform.position + bluePrint.offset;
        }

        private void OnMouseExit()
        {
            //rend.material.color = startColor;
            rend.material = startMaterial;

            rend.enabled = false;
        }
    }
}