using UnityEngine;

//���׸� Ŭ����: ���� �Ű����� T�� ������ �������� Ŭ������ ����� ������ �����ϴ� Ŭ����
namespace Sample
{
    public class Water
    {
        public string name;
    }

    public class Coffee { }

    //Ŭ���� �̸�<T> ���·� ���׸� Ŭ���� ����
    public class Cup<T>
    {
        public T Content { get; set; }
        public void PrintData(T data)
        {
            Debug.Log(data);
        }
    }
}