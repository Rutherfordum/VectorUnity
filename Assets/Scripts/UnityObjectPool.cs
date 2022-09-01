using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class UnityObjectPool<T> where T : MonoBehaviour
{
    private T prefab;
    private Transform container;
    private int count;

    private Queue<T> Pool;

    public UnityObjectPool(T prefab,int count, Transform container)
    {
        this.prefab = prefab;
        this.count = count;
        this.container = container;
        CreatePool();
    }

    private void CreatePool()
    {
        Pool = new Queue<T>();

        for (int i = 0; i < count; i++)
        {
           var obj =   Object.Instantiate(prefab, container);
           obj.gameObject.SetActive(false);
           IPooledObject pooledObject = obj as IPooledObject;
           if(pooledObject!=null)
               pooledObject.OnSpawn();
           Pool.Enqueue(obj);
        }
    }

    public T SpawnFromPool()
    {
        var obj = Pool.Dequeue();
        obj.gameObject.SetActive(true);
        Pool.Enqueue(obj);
        return obj;
    }
}
