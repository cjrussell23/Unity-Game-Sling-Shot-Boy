using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsContoller : MonoBehaviour
{
    private GameObject[] _spawners;
    private void Start()
    {
        _spawners = GameObject.FindGameObjectsWithTag("Spawner");
    }
    public void Spawn(int area)
    {
        foreach (GameObject go in _spawners)
        {
            var spawner = go.GetComponent<SpawnPoint>();
            int spawnerArea = spawner.Area;
            if (spawnerArea == area)
            {
                spawner.StartSpawning();
            }
        }
    }
}
