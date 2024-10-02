using UnityEngine;
using UnityEngine.EventSystems;

namespace MyDefence
{
    public class Tile : MonoBehaviour
    {
        #region Variables
        //���콺�� ���� ���� ���� Ÿ�� �÷���
        public Color hoverColor;
        public Material hoverMaterial;

        //���� ������ ���� �÷�
        public Color notEnoughColor;

        //�� Ÿ���� �⺻ �÷�
        private Color startColor;
        private Material startMaterial;

        //Ÿ�Ͽ� ��ġ�� �ͷ� ���� ������Ʈ ��ü
        private GameObject turret;

        //���� ���õ� �ͷ� bluePrint(prefab, cost, ...)
        public TurretBluePrint bluePrint;

        //����Ŵ���
        private BuildManager buildManager;

        //Ÿ�Ͽ� ������ ��ġ�Ǿ����� Ȯ���ϴ� �÷���
        //private bool isBuild = false;

        //������ �ν��Ͻ�
        private Renderer rend;

        //���� ����Ʈ ������
        public GameObject buildEffectPrefab;
        public GameObject sellEffectPrefab;

        //�ͷ� ���׷��̵� ����
        public bool IsUpgrade { get; private set; }
        #endregion

        private void Start()
        {
            //�ʱ�ȭ
            buildManager = BuildManager.Instance;

            rend = GetComponent<Renderer>();

            //startColor = rend.material.color
            startMaterial = rend.material;

            rend.enabled = false;

            IsUpgrade = false;
        }

        private void OnMouseEnter()
        {
            //���콺 �����Ͱ� UI ���� ������ 
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
            //���콺 �����Ͱ� UI ���� ������ 
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (turret != null)
            {
                //������ Ÿ���� ������ �Ѱ��ش�
                buildManager.SelectTile(this);
                return;
            }

            BuildTurret();
        }

        private void BuildTurret()
        {
            //��ġ�� �ͷ��� �Ӽ��� �������� (�ͷ� ������, �Ǽ� ���, ���׷��̵� ������, ...)
            bluePrint = buildManager.GetTurretToBuild();

            if (bluePrint == null)
                return;

            //���� �����Ѵ� 100, 250
            //Debug.Log($"�ͷ� �Ǽ����: {bluePrint.cost}");
            if (PlayerStats.SpendMoney(bluePrint.cost))
            {
                //�ͷ� �Ǽ� ����Ʈ
                GameObject effectGo = Instantiate(buildEffectPrefab, GetBuildPosition(), Quaternion.Euler(-90f, 0f, 0f));
                Destroy(effectGo, 2f);

                //�ͷ� �Ǽ�
                turret = Instantiate(bluePrint.turretPrefab, GetBuildPosition(), Quaternion.identity);

                //Debug.Log($"�Ǽ��ϰ� ���� ��: {PlayerStats.Money}");
            }
        }

        public void UpgradeTurret()
        {
            if (bluePrint == null) return;

            //���׷��̵� �ͷ��� ����
            if (PlayerStats.SpendMoney(bluePrint.upgradeCost))
            {
                //���� �ͷ��� �ı��ϰ�
                Destroy(turret);

                IsUpgrade = true;

                //�ͷ� �Ǽ� ����Ʈ
                GameObject effectGo = Instantiate(buildEffectPrefab, GetBuildPosition(), Quaternion.Euler(-90f, 0f, 0f));
                Destroy(effectGo, 2f);

                //���׷��̵� �ͷ� �Ǽ�
                turret = Instantiate(bluePrint.turretUpgradePrefab, GetBuildPosition(), Quaternion.identity);
            }
        }

        public void SellTurret()
        {
            if (bluePrint == null) return;

            int sellMoney = bluePrint.GetSellCost();

            //�ͷ� �ı�
            Destroy(turret);

            //�ͷ� �Ǹ� ����Ʈ
            GameObject effectGo = Instantiate(sellEffectPrefab, GetBuildPosition(), Quaternion.Euler(-90f, 0f, 0f));
            Destroy(effectGo, 2f);

            //�Ǽ� ���� ���� �ʱ�ȭ
            turret = null;
            bluePrint = null;
            IsUpgrade = false;

            //�Ǹ� ���� ����
            PlayerStats.EarnMoney(sellMoney);
        }

        //�ͷ� ��ġ ��ġ
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