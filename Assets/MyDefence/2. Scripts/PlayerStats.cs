using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyDefence
{
    //플레이어의 속성을 관리하는 클래스
    public class PlayerStats : MonoBehaviour
    {
        #region Variables
        //소지금
        private static int money;

        //소지금 읽기 전용 속성
        public static int Money
        {
            get { return money; }
            set { money = value; }
        }

        //게임 시작 시 지급하는 초기 소지금
        [SerializeField] private int startMoney = 1000;

        //라이프
        private static int life;

        //라이프 읽기 전용 속성
        public static int Life => life;

        //게임 시작 시 지급하는 초기 라이프
        [SerializeField] private int startLife = 10;

        //라운드
        private static int rounds;
        public static int Rounds
        {
            get { return rounds; }
            set { rounds = value; }
        }
        #endregion

        private void Start()
        {
            //초기화
            money = startMoney;
            life = startLife;
            rounds = 0;
        }

        //돈을 번다 : 사냥, 퀘스트 클리어, 캐시 구매
        public static void EarnMoney(int amount)
        {
            money += amount;
        }

        //돈을 쓴다 : 아이템 구매, ㅇㅇ 사용료
        public static bool SpendMoney(int amount)
        {
            //소지금 체크
            if (!HaveMoney(amount))
            {
                Debug.Log("소지금이 부족합니다");
                return false;
            }

            money -= amount;

            Debug.Log($"{amount} Item Purchase");

            return true;
        }

        //잔금 확인
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