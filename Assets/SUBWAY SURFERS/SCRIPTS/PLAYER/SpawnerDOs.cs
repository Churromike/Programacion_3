using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDOs : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int cantidad;
    [SerializeField] private float spawnTime;
    [SerializeField] private Transform[] spawns;
    private void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        for (int i = 0; i < cantidad; i++)
        {
            int spawn = Random.Range(0, spawns.Length);
            GameObject instance = Instantiate(prefab, spawns[spawn]);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
