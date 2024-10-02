using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    namespace ObjectTest
    {
        public class SingleTon
        {
            //필드
            private static SingleTon instance;

            //속성
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
상기 방법이 싱글톤 설계 방법이다.
이후에 이것을 사용할 땐 다음과 같이 쓴다.

    var objectA = SingleTon.Instance();
    var objectB = SingleTon.Instance();

    if (objectA == objectB)
        Debug.Log(objectA.ToString());

    이 결과, objectA와 objectB는 같은 것으로 본다.

그런데 유니티에서는 이미 이것이 구현되어있다!
 */