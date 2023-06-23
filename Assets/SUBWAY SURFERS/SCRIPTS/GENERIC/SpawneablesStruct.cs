using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SpawneablesStruct
{
    public string objectName;
    public Transform objectParent;
    public int objectsAmount;
    public GameObject[] objectToPool;
    public Queue<GameObject> pool;
    public float timeToDisable;
}