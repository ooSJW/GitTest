using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

#region Inner Class
public partial class PoolManager : MonoBehaviour // Inner Class
{
    public class Pool
    {
        private GameObject prefab;
        private List<GameObject> poolObjectList;
        private Transform parent;
        private int spawnCount;

        public Pool(GameObject prefabValue, int spawnCountVlaue = 10)
        {
            poolObjectList = new List<GameObject>();
            prefab = prefabValue;
            spawnCount = spawnCountVlaue;
            parent = new GameObject() { name = $"Root {prefab.name}" }.transform;
        }

        public void Register()
        {
            for (int i = 0; i < spawnCount; i++)
            {
                GameObject poolObject = Instantiate(prefab, parent.position, Quaternion.identity, parent);
                poolObject.name = prefab.name;
                poolObject.SetActive(false);
                poolObjectList.Add(poolObject);
            }
        }

        public GameObject Spawn(Vector2 spawnPosition = default)
        {
            GameObject poolObject = null;
            if (poolObjectList.Count > 0)
            {
                poolObject = poolObjectList[0];
                poolObjectList.RemoveAt(0);
                poolObject.SetActive(true);
            }
            else
            {
                poolObject = Instantiate(prefab, parent.position, Quaternion.identity, parent);
                poolObject.name = prefab.name;
            }
            if (spawnPosition != default)
                poolObject.transform.position = spawnPosition;
            return poolObject;
        }

        public void Despawn(GameObject despawnObject)
        {
            despawnObject.transform.SetParent(parent);
            poolObjectList.Add(despawnObject);
            despawnObject.SetActive(false);
        }
    }
}
#endregion

public partial class PoolManager : MonoBehaviour // DataField
{
    private Dictionary<string, Pool> poolDictionay;
}
public partial class PoolManager : MonoBehaviour // Initialize
{
    private void Allocate()
    {
        poolDictionay = new Dictionary<string, Pool>();
    }
    public void Initialize()
    {
        Allocate();
        Setup();
    }
    private void Setup()
    {

    }
}
public partial class PoolManager : MonoBehaviour // Property
{
    public void Register()
    {
        poolDictionay.Clear();
        List<GameObject> poolList = MainSystem.Instance.SceneManager.ActiveScene.poolableObjectList;
        for (int i = 0; i < poolList.Count; i++)
        {
            Pool pool = new Pool(poolList[i]);
            pool.Register();
            poolDictionay.Add(poolList[i].name, pool);
        }
    }

    public GameObject Spawn(string name, Vector2 spawnPosition = default)
    {
        return poolDictionay[name].Spawn(spawnPosition);
    }
    public void Despawn(GameObject despawnObject)
    {
        poolDictionay[despawnObject.name].Despawn(despawnObject);
    }
}