using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sample.ObjectTest;

namespace Sample
{
    public class GameObjectTest : MonoBehaviour
    {
        //�ʵ�
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
(���̾��Ű â�� �ִ�) ���� ������Ʈ�� gameObject, transform �����ϴ� ���, gameObject, transform�� ��ü�� �������� ���

1) gameObject�� ��ũ��Ʈ �ҽ��� ������Ʈ�� �߰��Ͽ� ����(this) �����´� : �ڱ� �ڽ�

2) �ٸ� ������Ʈ�� ���� �����ϴ� ���
. public���� ������ �� ����Ƽ �������� ���콺 Ŭ��+�巡�׷� ���� �Ҵ�

3) �ν��Ͻ� ���� �� �ʱ�ȭ �ܰ迡�� ���� Ű����� ���ǿ� �°� ã�Ƽ� �ʱ�ȭ
. ����Ƽ���� �����ϴ� API�� �̿� / GameObject.Find~ GetComponent~

4) prefab ���� ������Ʈ ���� �� Instantiate �Լ��� ��ȯ������ gameObject�� ��ü�� �����´�

5) �θ��ڽ� ���踦 �̿��ؼ� ���� ������Ʈ�� ��ü�� �����´�

6) static: Ŭ�����̸�.�ʵ��̸�, �̱���
 */