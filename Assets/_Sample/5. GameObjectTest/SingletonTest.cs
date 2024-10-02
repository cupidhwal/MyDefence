using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class SingletonTest : MonoBehaviour
    {
        //클래스의 인스턴스 변수를 static으로 선언
        private static SingletonTest instance;

        public static SingletonTest Instance
        {
            get
            {
                return instance;
            }
        }

        //실행과 동시에 
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;

            //gameObject는 신 종료시 파괴가 안 된다
            DontDestroyOnLoad(gameObject);
        }

        public int number;
    }
}