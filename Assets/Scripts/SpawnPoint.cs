using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private float _repeatInterval;
    [SerializeField] private int _maxSpawns;
    private int _spawns;
    public void Start()
    {
        _spawns = 0;
        if (_repeatInterval > 0 && _maxSpawns > 0)
        {
            InvokeRepeating("SpawnObject", 0.0f, _repeatInterval);
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
}
