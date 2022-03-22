using System.Collections.Generic;
using UnityEngine;
public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _ammoPrefab;
    private static List<GameObject> _ammoPool;
    [SerializeField] private int _poolSize = 7;
    [SerializeField] private float _weaponVelocity = 2;
    void Awake()
    {
        if (_ammoPool == null)
        {
            _ammoPool = new List<GameObject>();
        }
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject ammoObject = Instantiate(_ammoPrefab);
            ammoObject.SetActive(false);
            _ammoPool.Add(ammoObject);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireAmmo();
        }
    }
    public GameObject SpawnAmmo(Vector3 location)
    {
        foreach (GameObject ammo in _ammoPool)
        {
            if (ammo.activeSelf == false)
            {
                ammo.SetActive(true);
                ammo.transform.position = location;
                return ammo;
            }
        }
        return null;
    }
    void OnDestroy()
    {
        _ammoPool = null;
    }
    void FireAmmo()
    {
        Vector3 mousePosition =
        Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject ammo = SpawnAmmo(transform.position);
        if (ammo != null)
        {
            Arc arcScript = ammo.GetComponent<Arc>();
            float travelDuration = 1.0f / _weaponVelocity;
            StartCoroutine(arcScript.TravelArc(mousePosition, travelDuration));
        }
    }
}
