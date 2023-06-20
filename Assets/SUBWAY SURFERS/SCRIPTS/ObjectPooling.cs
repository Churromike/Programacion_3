using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{

    [SerializeField] private GameObject objectToPool; // Va el objeto que vamos a estar activando y desactivando
    [SerializeField] private int poolSize;

    [SerializeField] private Queue<GameObject> poolQueue = new Queue<GameObject>();

    [SerializeField] private float timeToDisable = 1.5f;
    private void Start()
    {
        InitialConfig();
    }

    private void InitialConfig() // Se crean los objetos que vamos a necesitar y añadir a la fila
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newObj = Instantiate(objectToPool);
            newObj.SetActive(false);
            poolQueue.Enqueue(newObj);
            newObj.transform.parent = this.transform;
        }

        StartCoroutine(PoolObjects());
    }

    private IEnumerator PoolObjects()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject instance = RequestObject();
            instance.transform.position = new Vector3(Random.Range(-5,5), Random.Range(-5, 5), Random.Range(-5, 5));
        }
    }

    private GameObject RequestObject() // Te regresa el objeto que sigue en la fila y lo activa
    {
        GameObject newObject = poolQueue.Dequeue();
        newObject.SetActive(true);
        StartCoroutine(DisableObject(newObject));

        return newObject;
    }

    private IEnumerator DisableObject(GameObject obj) // Desactiva el objeto actual y lo vuelve a poner en fila
    {
        yield return new WaitForSeconds(timeToDisable);
        obj.SetActive(false);
        poolQueue.Enqueue(obj);
    }
}
