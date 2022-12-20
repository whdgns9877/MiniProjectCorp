using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject poolingObj = null;

    Queue<GameObject> poolingQueue = new Queue<GameObject>();

    public GameObject Make()
    {
        if(poolingQueue.Count == 0)
        {
            GameObject instObj = Instantiate(poolingObj);
            return instObj;
        }
        else
        {
            return poolingQueue.Dequeue();
        }
    }

    public void Retrieve(GameObject obj)
    {
        poolingQueue.Enqueue(obj);
        obj.SetActive(false);
    }
}
