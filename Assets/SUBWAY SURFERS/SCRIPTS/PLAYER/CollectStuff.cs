using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectStuff : MonoBehaviour
{

    [SerializeField] private UnityEvent onGetJetpack;
    [SerializeField] private UnityEvent onGetMagnet;
    [SerializeField] private UnityEvent onGetPogo;
    [SerializeField] private UnityEvent onGetKey;
    [SerializeField] private UnityEvent onGetSkateboard;
    [SerializeField] private UnityEvent onGetPapos;
    [SerializeField] private UnityEvent onGetMisteryBox;
    [SerializeField] private UnityEvent onGetChar;
    [SerializeField] private UnityEvent onGetMultiplier;

    private void OnTriggerEnter(Collider other)
    {

        switch (other.tag)
        {
            case "Jetpack":
                {

                    break;

                }
            case "Magnet":
                {

                    break;

                }
            case "Pogo":
                {

                    break;

                }
            case "Key":
                {

                    break;

                }
            case "Skateboard":
                {

                    break;

                }
            case "Papos":
                {

                    break;

                }
            case "MisteryBox":
                {

                    break;

                }
            case "Char":
                {

                    break;

                }
            case "Multiplier":
                {

                    break;

                }
        }

    }


}
