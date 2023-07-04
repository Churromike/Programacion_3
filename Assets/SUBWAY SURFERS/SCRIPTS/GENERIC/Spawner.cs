using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private SpawneablesStruct[] objectsToSpawn;

    private void Start()
    {
        SpawnInitialObjects();
    }

    private void SpawnInitialObjects()
    {
        for (int i = 0; i < objectsToSpawn.Length; i++) // Para pasar de un struct a otro
        {
            objectsToSpawn[i].pool = new Queue<GameObject>();

            for (int j = 0; j < objectsToSpawn[i].objectToPool.Length; j++) // Para pasar de un objeto de un struct a otro objeto del mismo struct
            {
                for (int k = 0; k < objectsToSpawn[i].objectsAmount; k++) // Para instanciar esos objetos la cantidad de veces que indica nuestra variable
                {
                    GameObject objectInstance = Instantiate(objectsToSpawn[i].objectToPool[j]);
                    objectInstance.transform.parent = objectsToSpawn[i].objectParent;
                    objectsToSpawn[i].pool.Enqueue(objectInstance);
                    objectInstance.SetActive(false);
                }
            }
        }
    }

    private void PoolObjects()
    { 
    
        // Activar objetos random de el arreglo de structs // monedas // obstaculos // buffos // coleccionables
        // Que aparezcan aleatoriamente en los spawners // izquierda / centro / derecha
        // Despues de un tiempo se desactiven // usar la variable time to disable de los structs
    
    }

}
