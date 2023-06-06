using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI coinScoreText;

    public void UpdateScoreText(int score)
    {

        coinScoreText.text=score.ToString();

    }

}
