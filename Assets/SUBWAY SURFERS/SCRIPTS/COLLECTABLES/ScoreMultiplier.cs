using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreMultiplier : MonoBehaviour, ICollectable
{

    [SerializeField] private float buffDuration;
    public UnityEvent<bool> onCollectEvent;

    public void OnCollect()
    {
        StartCoroutine(MultiplierBuffDuration());
    }

    private IEnumerator MultiplierBuffDuration()
    {
        onCollectEvent.Invoke(true);

        yield return new WaitForSeconds(buffDuration);

        onCollectEvent.Invoke(false);
    }

}
