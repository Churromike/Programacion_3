using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectCoin : MonoBehaviour
{

    [SerializeField] private UnityEvent onGetCoin;

    private void OnTriggerEnter(Collider other)
    {

        switch (other.tag)
        {
            case "Coin":
                {
                    onGetCoin.Invoke();
                    break;

                }
        }

    }

}
