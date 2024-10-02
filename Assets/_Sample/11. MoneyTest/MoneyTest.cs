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

        //소지금
        private int gold;

        //게임 시작 시 지급하는 초기 소지금
        [SerializeField]private int startGold = 1000;

        private void Start()
        {
            //초기화
            gold = startGold;
            Debug.Log($"소지금 {startGold}를 지급하였습니다");
        }

        private void Update()
        {
            //버튼 색
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

        //잔금 확인
        public bool HaveMoney(int amount)
        {
            return gold >= amount;
        }

        //Save1000 버튼 클릭 시 호출
        public void Save1000()
        {
            EarnMoney(1000);
        }

        //Purchase1000 버튼 클릭 시 호출
        public void Purchase1000()
        {
            SpendMoney(1000);
        }

        //Purchase9000 버튼 클릭 시 호출
        public void Purchase9000()
        {
            SpendMoney(9000);
        }

        //돈을 번다 : 사냥, 퀘스트 클리어, 캐시 구매
        public void EarnMoney(int amount)
        {
            gold += amount;
        }

        //돈을 쓴다 : 아이템 구매, ㅇㅇ 사용료
        public void SpendMoney(int amount)
        {
            //소지금 체크
            if (!HaveMoney(amount))
            {
                Debug.Log("소지금이 부족합니다");
                return;
            }

            gold -= amount;

            Debug.Log($"{amount} Item Purchase");
        }
    }
}

/*
<샘플 씬>
//시작하면 소지금 1000원 지급
//상단  1000 Gold UI 적용

1. 저축 버튼 : 1000 저축
   버튼 클릭시 - "1000 Gold Save." 출력 Debug.Log

2. 구매 버튼 : 1000 아이템 구매 
   버튼 클릭시 - "1000 Gold Purchase"  출력 Debug.Log

3. 구매 버튼 : 9000 아이템 구매 -9000
  버튼 클릭시 - "9000 Gold Purchase"  출력 Debug.Log

= 구매 버튼에서 구매가 가능하면 버튼 이미지 컬러를 white
   구매가 불가능하면 red 구현
   구매가 불가능하면 구매 버튼을 클릭해도 구매가 안되어야 한다
 */