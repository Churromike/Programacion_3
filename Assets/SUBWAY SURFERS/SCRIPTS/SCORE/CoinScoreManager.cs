using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinScoreManager : MonoBehaviour
{

    [SerializeField] private int _score;
    [SerializeField] private bool isMultiplierActive;

    [SerializeField] private UnityEvent<int> updateScoreText;

    public int Score
    {
        get => _score;
        set => _score = value;
    }

    public void IncreaseScore()
    {

        Score++;

        updateScoreText?.Invoke(Score);

    }

}
