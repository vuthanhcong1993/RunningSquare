using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : Singleton<ObjectPool>
{
    #region Variables
    //[SerializeField]
    //private GameObject pooledObject = null;
    //[SerializeField]
    //private int pooledCount = 0;
    //[SerializeField]
    //private Transform parent = null;

    public List<ElementPool> pools = new List<ElementPool>();
    public Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();
    #endregion

    #region Unity Methods

    void Awake()
    {
        // CreateObjectStart();
        CreateOnStart();
    }

    void Update()
    {

    }

    //void CreateObjectStart()
    //{

    //    for (int u = 0; u < pooledCount; u++)
    //    {
    //        GameObject elementObject = Instantiate(pooledObject);
    //        pooledObjects.Add(elementObject);
    //        elementObject.transform.SetParent(parent);
    //        elementObject.SetActive(false);

    //    }


    //}

    //public GameObject GetPoolObject()
    //{

    //    for (int u = 0; u < pooledObjects.Count; u++)
    //    {
    //        if (!pooledObjects[u].activeSelf)
    //        {

    //            return pooledObjects[u];
    //        }
    //    }
    //    GameObject elementObject = Instantiate(pooledObject);
    //    pooledObjects.Add(elementObject);
    //    elementObject.transform.SetParent(parent);
    //    return null;

    //}

    void CreateOnStart()
    {
        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.countObject; i++)
            {
                GameObject obj = Instantiate(pool.objectPool, pool.parentObject);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tagPool, objectPool);
        }
    }

    public GameObject SpawnPool(string tagPool, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tagPool))
        {
            Debug.LogWarning("Dont have key pool");
            return null;

        }
        GameObject objectToSpawn = poolDictionary[tagPool].Peek();
        if (objectToSpawn.activeSelf)
        {
            objectToSpawn = Instantiate(poolDictionary[tagPool].Peek(), poolDictionary[tagPool].Peek().transform.parent);
        }
        else
        {
            poolDictionary[tagPool].Dequeue();
        }
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        IpooledObject pooledObj = objectToSpawn.GetComponent<IpooledObject>();
        if (pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }
        poolDictionary[tagPool].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

    public void DestroyGameobject(GameObject obj)
    {
        obj.SetActive(false);
    }
    #endregion 
}