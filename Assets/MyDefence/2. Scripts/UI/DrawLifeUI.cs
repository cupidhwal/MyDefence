using UnityEngine;
using TMPro;
using MyDefence;

public class DrawLifeUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI lifeText;

    // Update is called once per frame
    void Update()
    {
        lifeText.text = PlayerStats.Life.ToString();
    }
}
