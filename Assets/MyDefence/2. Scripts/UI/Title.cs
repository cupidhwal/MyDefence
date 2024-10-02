using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class Title : MonoBehaviour
    {
        //ÇÊµå
        [SerializeField] private int startTime;
        [SerializeField] private bool isStart;
        [SerializeField] private bool isLoad;
        public string loadToScene = "MainMenu";

        public GameObject anyKey;
        public SceneFader fader;

        private void Start()
        {
            startTime = 10;

            isStart = false;
            isLoad = false;

            StartCoroutine(GameLoad(3));
            StartCoroutine(GameStart(startTime));
        }

        // Update is called once per frame
        void Update()
        {
            if (isLoad == false) return;

            if (Input.anyKeyDown || isStart)
            {
                StopAllCoroutines();
                fader.FadeTo(loadToScene);
            }
        }

        IEnumerator GameLoad(int time)
        {
            yield return new WaitForSeconds(time);
            isLoad = true;
            anyKey.SetActive(isLoad);
        }

        IEnumerator GameStart(int time)
        {
            yield return new WaitForSeconds(time);
            isStart = true;
        }
    }
}