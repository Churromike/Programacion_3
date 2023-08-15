using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CoinScoreManager : MonoBehaviour
{

    [SerializeField] private int _score;
    [SerializeField] private bool isMultiplierActive;

    [SerializeField] private UnityEvent<int> updateScoreText;
    [SerializeField] private UnityEvent<int> updateMaxScoreText;

    public int Score
    {
        get => _score;
        set => _score = value;
    }

    public void IncreaseScore()
    {
        _score++;
        updateScoreText?.Invoke(_score);

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            IncreaseScore();
        }
    }

    private void OnEnable()
    {
        _score = 0;
        updateScoreText?.Invoke(_score);
    }

    private void OnDisable()
    {
        // Guardar el score localmente
        if (PlayerPrefs.HasKey("CoinScore")) // En caso de que exista algun score guardado
        {
            int previousScore = PlayerPrefs.GetInt("CoinScore");
            Debug.Log(previousScore);

            if (_score > previousScore)
            {
                PlayerPrefs.SetInt("CoinScore", _score); // Este sera el nuevo max score
                updateMaxScoreText?.Invoke(_score);
            }
            else
            {
                updateMaxScoreText?.Invoke(previousScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("CoinScore", _score); // Este de aqui es el primer score
            updateMaxScoreText?.Invoke(_score);
        }

    }

    public void EnableScript()
    {
        enabled = true;
    }

    public void DisableScript()
    {
        enabled = false;
    }

}
