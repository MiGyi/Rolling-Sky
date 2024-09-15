using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private List<T> pool = new List<T>();

    private T prefab;

    public ObjectPool(T prefab)
    {
        this.prefab = prefab;
    }
    public T GetObject(T prefab, Vector3 position, Quaternion rotation)
    {
        T obj;
        if (pool.Count > 0)
        {
            obj = pool[0];
            pool.RemoveAt(0);
            obj.gameObject.SetActive(true);
            obj.transform.position = position;
            obj.transform.rotation = rotation;
        }
        else
        {
            obj = GameObject.Instantiate(prefab, position, rotation);
        }
        return obj;
    }

    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Add(obj);
    }
}