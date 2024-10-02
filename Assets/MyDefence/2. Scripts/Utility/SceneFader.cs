using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class SceneFader : MonoBehaviour
    {
        #region Variables
        //Fader �̹���
        public Image image;
        public AnimationCurve curve;
        #endregion

        private void Start()
        {
            StartCoroutine(FadeIn());
        }

        public void FadeTo(string sceneName)
        {
            StartCoroutine(FadeOut(sceneName));
        }

        IEnumerator FadeIn()
        {
            //1�� ���� image a1 -> a0

            float t = 1;

            while (t > 0)
            {
                t -= Time.deltaTime;
                float a = curve.Evaluate(t);
                image.color = new Color(0f, 0f, 0f, a);

                yield return 0f;
            }
        }

        IEnumerator FadeOut(string sceneName)
        {
            //1�� ���� image a0 -> a1

            float t = 0;

            while (t < 1)
            {
                t += Time.deltaTime;
                float a = curve.Evaluate(t);
                image.color = new Color(0f, 0f, 0f, a);

                yield return 0f;
            }

            //���� �� �ε�
            SceneManager.LoadScene(sceneName);
        }
    }
}