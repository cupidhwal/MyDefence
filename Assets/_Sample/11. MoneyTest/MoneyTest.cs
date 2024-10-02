using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Sample
{
    public class MoneyTest : MonoBehaviour
    {
        public Canvas moneyUI;
        public TextMeshProUGUI moneyText;
        public Button button1000;
        public Button button9000;

        //������
        private int gold;

        //���� ���� �� �����ϴ� �ʱ� ������
        [SerializeField]private int startGold = 1000;

        private void Start()
        {
            //�ʱ�ȭ
            gold = startGold;
            Debug.Log($"������ {startGold}�� �����Ͽ����ϴ�");
        }

        private void Update()
        {
            //��ư ��
            if (HaveMoney(1000))
            {
                button1000.image.color = Color.white;
            }

            else
                button1000.image.color = Color.red;

            if (HaveMoney(9000))
            {
                button9000.image.color = Color.white;
            }

            else
                button9000.image.color = Color.red;

            //Money UI
            moneyText.text = gold.ToString() + " Gold";
        }

        private void ABD()
        {

        }

        //�ܱ� Ȯ��
        public bool HaveMoney(int amount)
        {
            return gold >= amount;
        }

        //Save1000 ��ư Ŭ�� �� ȣ��
        public void Save1000()
        {
            EarnMoney(1000);
        }

        //Purchase1000 ��ư Ŭ�� �� ȣ��
        public void Purchase1000()
        {
            SpendMoney(1000);
        }

        //Purchase9000 ��ư Ŭ�� �� ȣ��
        public void Purchase9000()
        {
            SpendMoney(9000);
        }

        //���� ���� : ���, ����Ʈ Ŭ����, ĳ�� ����
        public void EarnMoney(int amount)
        {
            gold += amount;
        }

        //���� ���� : ������ ����, ���� ����
        public void SpendMoney(int amount)
        {
            //������ üũ
            if (!HaveMoney(amount))
            {
                Debug.Log("�������� �����մϴ�");
                return;
            }

            gold -= amount;

            Debug.Log($"{amount} Item Purchase");
        }
    }
}

/*
<���� ��>
//�����ϸ� ������ 1000�� ����
//���  1000 Gold UI ����

1. ���� ��ư : 1000 ����
   ��ư Ŭ���� - "1000 Gold Save." ��� Debug.Log

2. ���� ��ư : 1000 ������ ���� 
   ��ư Ŭ���� - "1000 Gold Purchase"  ��� Debug.Log

3. ���� ��ư : 9000 ������ ���� -9000
  ��ư Ŭ���� - "9000 Gold Purchase"  ��� Debug.Log

= ���� ��ư���� ���Ű� �����ϸ� ��ư �̹��� �÷��� white
   ���Ű� �Ұ����ϸ� red ����
   ���Ű� �Ұ����ϸ� ���� ��ư�� Ŭ���ص� ���Ű� �ȵǾ�� �Ѵ�
 */