using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

class Pool

{
    GameObject prefabs;
    IObjectPool<GameObject> pool;

    Transform root;
    Transform Root
    {
        get
        {
            if( root ==null )
            {
                GameObject go = new GameObject() { name = $"{prefabs.name}Pool" };
                root = go.transform;
            }
            return root;
        }
    }


    public Pool(GameObject prefab)
    {
        prefabs = prefab;
        pool = new ObjectPool<GameObject>(OnCreate, OnSet, OnRelease, OnDestroy);

    }
    public void Push (GameObject go)
    {
        if (go.activeSelf)
            pool.Release(go);

    }

    public GameObject Pop()
    {
        return pool.Get();
    }

    GameObject OnCreate()
    {
        GameObject go = GameObject.Instantiate(prefabs);
        go.transform.SetParent(Root);
        go.name = prefabs.name;
        return go;
    }
    void OnSet(GameObject go)
    {
        go.SetActive(true);
    }
    void OnRelease(GameObject go)
    {
        go.SetActive(false);

    }
    void OnDestroy(GameObject go)
    {
        GameObject.Destroy(go);
    }
}


public class PoolManager 
{
    Dictionary<string, Pool> pools = new Dictionary<string, Pool>();

    public GameObject Pop (GameObject prefab)
    {
        if( pools.ContainsKey(prefab.name )== false)
        {
            CreatePool(prefab);

        }
        return pools[prefab.name].Pop();

    }

    public bool Push(GameObject go)
    {
        if( pools .ContainsKey(go.name )== false)
        {
            return false;
        }
        pools[go.name].Push(go);
        return true;
    }




    public void Clear()
    {
        pools.Clear();
    }

    void CreatePool(GameObject Original)
    {
        Pool pool = new Pool(Original);
        pools.Add(Original.name, pool);
    }

    public void Destroy(GameObject go)
    {

        if (go == null) return;
        if (Push(go)) return;
        Object.Destroy(go);
    }

}
