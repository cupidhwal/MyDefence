using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    namespace ObjectTest
    {
        public class SingleTon
        {
            //�ʵ�
            private static SingleTon instance;

            //�Ӽ�
            public static SingleTon Instance
            {
                get
                {
                    if (instance == null)
                        instance = new SingleTon();

                    return instance;
                }
            }

            /*public static SingleTon Instance()
            {
                if (instance == null)
                    instance = new SingleTon();

                return instance;
            }*/
        }
    }
}

/*
��� ����� �̱��� ���� ����̴�.
���Ŀ� �̰��� ����� �� ������ ���� ����.

    var objectA = SingleTon.Instance();
    var objectB = SingleTon.Instance();

    if (objectA == objectB)
        Debug.Log(objectA.ToString());

    �� ���, objectA�� objectB�� ���� ������ ����.

�׷��� ����Ƽ������ �̹� �̰��� �����Ǿ��ִ�!
 */