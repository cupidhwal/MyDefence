using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sample.ObjectTest;

namespace Sample
{
    public class GameObjectTest : MonoBehaviour
    {
        //필드
        //2)
        public Transform publicTransform;
        public GameObject publicObject;

        //3)
        private GameObject tagObject;
        private GameObject[] tagObjects;

        //4)
        public GameObject prefabObject;

        //5)
        public Transform parentObject;
        private Transform[] childObjects;

        // Start is called before the first frame update
        void Start()
        {
            /*//1)
            //this.gameObject
            //this.transform

            //2)
            //publicTransform.GetComponent<>;

            //3)
            tagObject = GameObject.FindGameObjectWithTag("Tag");
            tagObjects = GameObject.FindGameObjectsWithTag("Tag");

            //4)
            GameObject prefabGo = Instantiate(prefabObject, this.transform.position, Quaternion.identity);

            //5)
            childObjects = new Transform[parentObject.childCount];
            for (int i = 0; i < childObjects.Length; i++)
            {
                childObjects[i] = parentObject.GetChild(i);
            }

            //6)
            StaticClass.number = 10;*/

            //Singleton
            //SingleTon singleTon = new SingleTon();
            //Debug.Log(singleTon.ToString());

            var objectA = SingleTon.Instance;
            var objectB = SingleTon.Instance;

            if (objectA == objectB)
                Debug.Log(objectA.ToString());
        }
    }
}

/*
(하이어라키 창에 있는) 게임 오브젝트의 gameObject, transform 접근하는 방법, gameObject, transform의 객체를 가져오는 방법

1) gameObject에 스크립트 소스를 컴포넌트로 추가하여 직접(this) 가져온다 : 자기 자신

2) 다른 오브젝트의 값을 참조하는 방법
. public으로 선언한 뒤 유니티 엔진에서 마우스 클릭+드래그로 직접 할당

3) 인스턴스 선언 및 초기화 단계에서 여러 키워드로 조건에 맞게 찾아서 초기화
. 유니티에서 제공하는 API를 이용 / GameObject.Find~ GetComponent~

4) prefab 게임 오브젝트 생성 시 Instantiate 함수의 반환값으로 gameObject의 객체를 가져온다

5) 부모자식 관계를 이용해서 게임 오브젝트의 객체를 가져온다

6) static: 클래스이름.필드이름, 싱글톤
 */