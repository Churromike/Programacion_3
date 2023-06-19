using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceScoreManager : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private float scoreMultiplier;
    [SerializeField] private bool isBuffActive;

    private void Update()
    {

        _time += RealTime();

    }

    public float RealTime()
    {

        return (isBuffActive ? Time.deltaTime * 2 : Time.deltaTime) * scoreMultiplier;

    }

    public void ActivateScoreBuff(bool value)
    {

        isBuffActive = value;

    }

}
