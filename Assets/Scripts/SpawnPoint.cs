using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private float _repeatInterval;
    [SerializeField] private int _maxSpawns;
    [SerializeField] private int _area = -1;
    private int _spawns;
    public void Start()
    {
        _spawns = 0;
        // Value -1 means no specified ground area, so just start spawning at start.
        if (_area == -1)
        {
            StartSpawning();
        }
    }
    public GameObject SpawnObject()
    {      
        if (_prefabToSpawn != null)
        {
            _spawns += 1;
            return Instantiate(_prefabToSpawn, transform.position, Quaternion.identity);
        }       
        return null;
    }
    public void FixedUpdate()
    {
        if (_spawns >= _maxSpawns)
        {
            CancelInvoke();
        }
    }
    public void StartSpawning()
    {
        if (_repeatInterval > 0 && _maxSpawns > 0)
        {
            InvokeRepeating("SpawnObject", 0.0f, _repeatInterval);
            Debug.Log($"Started spawner in {_area}");
        }
    }
    public int Area
    {
        get { return _area; }
    }
}
