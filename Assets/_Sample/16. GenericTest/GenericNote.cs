using UnityEngine;

namespace Sample
{
    public class GenericNote : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //Cup 클래스의 인스턴스 선언하고 생성
            //Cup c = new Cup();        //사용 불가

            //T: string 전용 - 문자열 컨텐츠를 저장하는 속성 생성
            Cup<string> text = new Cup<string>();
            text.Content = "문자열";

            //T: int 전용 - 정수형 컨텐츠를 저장하는 속성 생성
            Cup<int> number = new Cup<int>();
            number.Content = 1234;

            Debug.Log(text);
            Debug.Log(text.Content);
            Debug.Log(number);
            Debug.Log(number.Content);

            //T: 물컵 Water 전용 - Water의 클래스의 객체를 저장하는 속성 생성
            Cup<Water> water = new Cup<Water>();
            //water.Content는 Water의 인스턴스
            water.Content = new Water();
            water.Content.name = "홍길동";
            Debug.Log(water.Content);
            Debug.Log(water.Content.name);

            //T: 커피컵 Coffee 전용 - Coffee의 클래스의 객체를 저장하는 속성 생성
            Cup<Coffee> coffee = new Cup<Coffee>();
            coffee.Content = new Coffee();
            Debug.Log(coffee.Content.ToString());

            //Singleton<T> 테스트
            SingletonTest2.Instance.number = 5678;
            Debug.Log($"SingletonTest2.Instance.number : {SingletonTest2.Instance.number}");
        }
    }
}