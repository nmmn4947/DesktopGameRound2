using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject Object;
    [SerializeField] private int InitialCount;
    private List<GameObject> Pool = null;
    private int UsedCount = 0;

    void Awake()
    {
        for(int i = 0; i < InitialCount; i++)
            AddNewInstance();
    }

    protected GameObject AddNewInstance()
    {
        GameObject instance = Instantiate(Object);
        instance.AddComponent<PoolableObject>();
        instance.SetActive(false);
    
        return instance;
    }

    public GameObject GetAvailable()
    {
        foreach(var obj in Pool)
            if(!obj.gameObject.activeInHierarchy)
                return obj;

        return AddNewInstance();
    }

    void OnDestroy()
    {
        Pool.Clear();
        Pool = null;
    }
}