using UnityEngine;

namespace Sample
{
    public class GenericNote : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //Cup Ŭ������ �ν��Ͻ� �����ϰ� ����
            //Cup c = new Cup();        //��� �Ұ�

            //T: string ���� - ���ڿ� �������� �����ϴ� �Ӽ� ����
            Cup<string> text = new Cup<string>();
            text.Content = "���ڿ�";

            //T: int ���� - ������ �������� �����ϴ� �Ӽ� ����
            Cup<int> number = new Cup<int>();
            number.Content = 1234;

            Debug.Log(text);
            Debug.Log(text.Content);
            Debug.Log(number);
            Debug.Log(number.Content);

            //T: ���� Water ���� - Water�� Ŭ������ ��ü�� �����ϴ� �Ӽ� ����
            Cup<Water> water = new Cup<Water>();
            //water.Content�� Water�� �ν��Ͻ�
            water.Content = new Water();
            water.Content.name = "ȫ�浿";
            Debug.Log(water.Content);
            Debug.Log(water.Content.name);

            //T: Ŀ���� Coffee ���� - Coffee�� Ŭ������ ��ü�� �����ϴ� �Ӽ� ����
            Cup<Coffee> coffee = new Cup<Coffee>();
            coffee.Content = new Coffee();
            Debug.Log(coffee.Content.ToString());

            //Singleton<T> �׽�Ʈ
            SingletonTest2.Instance.number = 5678;
            Debug.Log($"SingletonTest2.Instance.number : {SingletonTest2.Instance.number}");
        }
    }
}