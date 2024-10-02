using System.Collections;
using UnityEngine;
using TMPro;

namespace MyDefence
{
    public class AnimateNumber : MonoBehaviour
    {
        public TextMeshProUGUI roundText;
        [SerializeField] private float animateDelay = 0.05f;

        void OnEnable()
        {
            StartCoroutine(AnimationNumber(PlayerStats.Rounds));
        }

        IEnumerator AnimationNumber(int targetNumber)
        {
            int aniNumber = 0;
            roundText.text = aniNumber.ToString();

            yield return new WaitForSeconds(0.1f);

            while (aniNumber < targetNumber)
            {
                aniNumber++;
                roundText.text = aniNumber.ToString();

                yield return new WaitForSeconds(animateDelay);
            }

        }
    }
}