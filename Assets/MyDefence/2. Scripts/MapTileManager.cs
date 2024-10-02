using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace MyDefence
{
    public class MapTileManager : MonoBehaviour
    {
        //필드
        //맵타일 총괄 오브젝트
        public GameObject parent;
        //맵타일 프리팹
        public GameObject tilePrefab;

        //맵타일 생성 여부 확인
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
            /*Debug.Log("스타트 코루틴 함수 호출");
            StartCoroutine(GenerateMapTile());*/

            //[6] 10x10 맵 타일 생성하는데 타일 하나씩 찍기
            //하나 찍고 0.1초 지연 후 다음 타일 찍기
            //StartCoroutine(GenerateMapTileBySeconds());
        }

        // Update is called once per frame
        void Update()
        {
            if (isCreate == false)
            {
                Debug.Log("코루틴 함수 호출");
                StartCoroutine(GenerateMapTileBySeconds());

                Debug.Log("코루틴 함수 호출 완료");
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
            Debug.Log("코루틴 함수 시작");
            //1초 지연
            yield return new WaitForSeconds(2f);

            Debug.Log("2초 지연 후 맵 타일 생성");
            Vector3 mapPosition = new Vector3(5f, 0f, 8f);
            Instantiate(tilePrefab, mapPosition, Quaternion.identity);

            yield return new WaitForSeconds(2f);

            Debug.Log("2초 지연 후 맵 타일 생성");
            Vector3 mapPosition2 = new Vector3(8f, 0f, 5f);
            Instantiate(tilePrefab, mapPosition2, Quaternion.identity);

            Debug.Log("코루틴 함수 종료");
        }

        //10x10 맵 제네레이터 만들기
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

        //랜덤 맵 타일 생성기
        //내 방식: 먼저 이차 배열 형태로 포지션을 생성하고, 그 중에서 10개를 뽑아 해시테이블로 저장한 뒤 포이치문으로 출력
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

        //오버로드 - 배열 크기 조절 가능
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

        //선생님 방법
        //중복을 걸러낼 로직 추가 필요
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