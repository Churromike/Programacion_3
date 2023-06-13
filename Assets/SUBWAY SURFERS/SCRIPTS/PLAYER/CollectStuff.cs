using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectStuff : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Collectable")
        {
            other.GetComponent<ICollectable>().OnCollect();
        }

    }


}
