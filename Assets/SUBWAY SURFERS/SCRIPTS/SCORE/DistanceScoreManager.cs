using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class DistanceScoreManager : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float scoreMultiplier;
    [SerializeField] private bool isBuffActive;

    [SerializeField] private UnityEvent<float> updateMaxScoreText;


    private void Update()
    {

        _distance += RealTime();

    }

    public float RealTime()
    {

        return (isBuffActive ? Time.deltaTime * 2 : Time.deltaTime) * scoreMultiplier;

    }

    public void ActivateScoreBuff(bool value)
    {

        isBuffActive = value;

    }

    private void OnEnable()
    {
        _distance = 0;
    }

    private void OnDisable()
    {
        // Guardar el score localmente
        if (PlayerPrefs.HasKey("DistanceScore")) // En caso de que exista algun score guardado
        {
            float previousScore = PlayerPrefs.GetFloat("DistanceScore");

            if (_distance > previousScore)
            {
                PlayerPrefs.SetFloat("DistanceScore", _distance); // Este sera el nuevo max score
                updateMaxScoreText?.Invoke(_distance);
            }
            else
            {
                updateMaxScoreText?.Invoke(_distance);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("DistanceScore", _distance); // Este de aqui es el primer score
            updateMaxScoreText?.Invoke(_distance);
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
