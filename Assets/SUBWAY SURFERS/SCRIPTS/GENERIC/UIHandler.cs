using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;

public class UIHandler : MonoBehaviour
{

    [Header("Gameplay")]
    [SerializeField] private TextMeshProUGUI coinScoreText;
    [SerializeField] private TextMeshProUGUI distanceScoreText;

    [Header("Menu")]
    [SerializeField] private GameObject startButton;
    [SerializeField] private TextMeshProUGUI coinMaxScore;
    [SerializeField] private TextMeshProUGUI distanceMaxScore;

    public void UpdateScoreText(int score)
    {
        coinScoreText.text=score.ToString();
    }

    public void UpdateDistanceScoreText(float distance)
    {
        distanceScoreText.text = distance.ToString();
    }

    public void UpdateCoinMaxScoreText(int maxScore)
    {
        coinMaxScore.text = "Coin Max Score: " + maxScore.ToString();
    }

    public void UpdateDistanceMaxScoreText(float maxScore)
    {
        distanceMaxScore.text = "D Max Score: " + maxScore;
    }

    public void EnableGameplayUI()
    {
        coinScoreText.gameObject.SetActive(true);
        distanceScoreText.enabled = true;
    }

    public void DisableGameplayUI()
    {
        coinScoreText.gameObject.SetActive(false);
        distanceScoreText.enabled = false;
    }

    public void EnableMenuUI()
    {
        startButton.SetActive(true);
        coinMaxScore.gameObject.SetActive(true);
        distanceMaxScore.enabled = true;
    }

    public void DisableMenuUI()
    {
        startButton.SetActive(false);
        coinMaxScore.gameObject.SetActive(false);
        distanceMaxScore.enabled = false;
        Debug.Log("5");
    }

}
