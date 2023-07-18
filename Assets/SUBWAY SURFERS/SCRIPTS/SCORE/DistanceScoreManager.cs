using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceScoreManager : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float scoreMultiplier;
    [SerializeField] private bool isBuffActive;

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
        PlayerPrefs.SetFloat("DistanceScore", _distance);
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
