using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyDefence
{
    //�÷��̾��� �Ӽ��� �����ϴ� Ŭ����
    public class PlayerStats : MonoBehaviour
    {
        #region Variables
        //������
        private static int money;

        //������ �б� ���� �Ӽ�
        public static int Money
        {
            get { return money; }
            set { money = value; }
        }

        //���� ���� �� �����ϴ� �ʱ� ������
        [SerializeField] private int startMoney = 1000;

        //������
        private static int life;

        //������ �б� ���� �Ӽ�
        public static int Life => life;

        //���� ���� �� �����ϴ� �ʱ� ������
        [SerializeField] private int startLife = 10;

        //����
        private static int rounds;
        public static int Rounds
        {
            get { return rounds; }
            set { rounds = value; }
        }
        #endregion

        private void Start()
        {
            //�ʱ�ȭ
            money = startMoney;
            life = startLife;
            rounds = 0;
        }

        //���� ���� : ���, ����Ʈ Ŭ����, ĳ�� ����
        public static void EarnMoney(int amount)
        {
            money += amount;
        }

        //���� ���� : ������ ����, ���� ����
        public static bool SpendMoney(int amount)
        {
            //������ üũ
            if (!HaveMoney(amount))
            {
                Debug.Log("�������� �����մϴ�");
                return false;
            }

            money -= amount;

            Debug.Log($"{amount} Item Purchase");

            return true;
        }

        //�ܱ� Ȯ��
        public static bool HaveMoney(int amount)
        {
            return money >= amount;
        }

        public static void AddLife(int amount)
        {
            life += amount;
        }

        public static void UseLife(int amount)
        {
            life -= amount;

            if (life <= 0)
            {
                life = 0;
            }
        }
    }
}