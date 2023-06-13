using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JumpBuff : MonoBehaviour, ICollectable
{

    [SerializeField] private float buffDuration;
    public UnityEvent<bool> onCollectEvent;

    public void OnCollect()
    {
        StartCoroutine(JumpBuffDuration());
    }

    private IEnumerator JumpBuffDuration()
    {
        onCollectEvent.Invoke(true); // Hace el isBuffActive verdadero

        yield return new WaitForSeconds(buffDuration);

        onCollectEvent.Invoke(false); // Hace el isBuffActive falso
    }

}
