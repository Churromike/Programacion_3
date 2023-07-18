using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;

public class UIHandler : MonoBehaviour
{

    [Header("Scores")]
    [SerializeField] private TextMeshProUGUI coinScoreText;
    [SerializeField] private TextMeshProUGUI distanceScoreText;

    [Header("UI")]
    [SerializeField] private GameObject startButton;

    public void UpdateScoreText(int score)
    {
        coinScoreText.text=score.ToString();
    }

    public void UpdateDistanceScoreText(float distance)
    {
        distanceScoreText.text = distance.ToString();
    }

    public void EnableUI()
    {
        coinScoreText.gameObject.SetActive(true);
        distanceScoreText.enabled = true;
        startButton.SetActive(false);
    }

    public void DisableUI()
    {
        coinScoreText.gameObject.SetActive(false);
        distanceScoreText.enabled = false;
        startButton.SetActive(true);
    }

}
