using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace MyDefence
{
    public class MapTileManager : MonoBehaviour
    {
        //�ʵ�
        //��Ÿ�� �Ѱ� ������Ʈ
        public GameObject parent;
        //��Ÿ�� ������
        public GameObject tilePrefab;

        //��Ÿ�� ���� ���� Ȯ��
        private bool isCreate = false;

        // Start is called before the first frame update
        void Start()
        {
            //
            /*Vector3 position = new Vector3(5f, 0f, 8f);
            Instantiate(tilePrefab, position, Quaternion.identity);*/

            //CreateRandomMapTile(20);

            //GenerateRandomMapTile(20);

            //
            /*Debug.Log("��ŸƮ �ڷ�ƾ �Լ� ȣ��");
            StartCoroutine(GenerateMapTile());*/

            //[6] 10x10 �� Ÿ�� �����ϴµ� Ÿ�� �ϳ��� ���
            //�ϳ� ��� 0.1�� ���� �� ���� Ÿ�� ���
            //StartCoroutine(GenerateMapTileBySeconds());
        }

        // Update is called once per frame
        void Update()
        {
            if (isCreate == false)
            {
                Debug.Log("�ڷ�ƾ �Լ� ȣ��");
                StartCoroutine(GenerateMapTileBySeconds());

                Debug.Log("�ڷ�ƾ �Լ� ȣ�� �Ϸ�");
                isCreate = true;
            }
        }

        IEnumerator GenerateMapTileBySeconds()
        {
            parent = Instantiate(parent);

            Vector3[,] mapPosition = new Vector3[10, 10];
            GameObject[,] tiles = new GameObject[10, 10];

            yield return new WaitForSeconds(0.1f);

            for (int i = 0; i < mapPosition.GetLength(0); i++)
            {
                for (int j = 0; j < mapPosition.GetLength(1); j++)
                {
                    mapPosition[i, j] = new Vector3((float)j * 1.1f, (float)0f, (float)i * 1.1f);

                    tiles[i, j] = Instantiate(tilePrefab, mapPosition[i, j], Quaternion.identity, parent.transform);

                    yield return new WaitForSeconds(0.1f);
                }
            }

            foreach (var tile in tiles)
            {
                Destroy(tile);
                yield return new WaitForSeconds(0.1f);
            }

            Destroy(parent);

            isCreate = false;
        }

        IEnumerator GenerateMapTile()
        {
            //
            Debug.Log("�ڷ�ƾ �Լ� ����");
            //1�� ����
            yield return new WaitForSeconds(2f);

            Debug.Log("2�� ���� �� �� Ÿ�� ����");
            Vector3 mapPosition = new Vector3(5f, 0f, 8f);
            Instantiate(tilePrefab, mapPosition, Quaternion.identity);

            yield return new WaitForSeconds(2f);

            Debug.Log("2�� ���� �� �� Ÿ�� ����");
            Vector3 mapPosition2 = new Vector3(8f, 0f, 5f);
            Instantiate(tilePrefab, mapPosition2, Quaternion.identity);

            Debug.Log("�ڷ�ƾ �Լ� ����");
        }

        //10x10 �� ���׷����� �����
        void CreateMapTile(int x, int y)
        {
            parent = Instantiate(parent);

            Vector3[,] mapPosition = new Vector3[x, y];

            for (int i = 0; i < mapPosition.GetLength(0); i++)
            {
                for (int j = 0; j < mapPosition.GetLength(1); j++)
                {
                    mapPosition[i, j] = new Vector3 ((float)i * 1.1f, (float)0f, (float)j * 1.1f);

                    Instantiate(tilePrefab, mapPosition[i, j], Quaternion.identity, parent.transform);
                }
            }
        }

        //���� �� Ÿ�� ������
        //�� ���: ���� ���� �迭 ���·� �������� �����ϰ�, �� �߿��� 10���� �̾� �ؽ����̺�� ������ �� ����ġ������ ���
        void CreateRandomMapTile(int n)
        {
            parent = Instantiate(parent);

            Vector3[,] mapPosition = new Vector3[10, 10];

            for (int i = 0; i < mapPosition.GetLength(0); i++)
            {
                for (int j = 0; j < mapPosition.GetLength(1); j++)
                {
                    mapPosition[i, j] = new Vector3((float)i * 1.1f, (float)0f, (float)j * 1.1f);
                }
            }

            System.Random rand = new System.Random();

            HashSet<Vector3> selectedPositions = new HashSet<Vector3>();

            while (selectedPositions.Count < n)
            {
                int randomRow = rand.Next(0, mapPosition.GetLength(0));
                int randomCol = rand.Next(0, mapPosition.GetLength(1));

                Vector3 randomPosition = mapPosition[randomRow, randomCol];

                selectedPositions.Add(randomPosition);
            }


            foreach (Vector3 pos in selectedPositions)
            {
                Instantiate(tilePrefab, pos, Quaternion.identity, parent.transform);
            }
        }

        //�����ε� - �迭 ũ�� ���� ����
        void CreateRandomMapTile(int x, int y, int n)
        {
            parent = Instantiate(parent);

            Vector3[,] mapPosition = new Vector3[x, y];

            for (int i = 0; i < mapPosition.GetLength(0); i++)
            {
                for (int j = 0; j < mapPosition.GetLength(1); j++)
                {
                    mapPosition[i, j] = new Vector3((float)i * 1.1f, (float)0f, (float)j * 1.1f);
                }
            }

            System.Random rand = new System.Random();

            HashSet<Vector3> selectedPositions = new HashSet<Vector3>();

            while (selectedPositions.Count < n)
            {
                int randomRow = rand.Next(0, mapPosition.GetLength(0));
                int randomCol = rand.Next(0, mapPosition.GetLength(1));

                Vector3 randomPosition = mapPosition[randomRow, randomCol];

                selectedPositions.Add(randomPosition);
            }


            foreach (Vector3 pos in selectedPositions)
            {
                Instantiate(tilePrefab, pos, Quaternion.identity, parent.transform);
            }
        }

        //������ ���
        //�ߺ��� �ɷ��� ���� �߰� �ʿ�
        void GenerateRandomMapTile(int n)
        {
            int i = 0, j = 0;

            for (int k = 0; k < n; k++)
            {
                i = Random.Range(0, 10);
                j = Random.Range(0, 10);

                Vector3 mapPosition = new Vector3((float)i * 1.1f, (float)0f, (float)j * 1.1f);

                Instantiate(tilePrefab, mapPosition, Quaternion.identity, parent.transform);
            }
        }
    }
}