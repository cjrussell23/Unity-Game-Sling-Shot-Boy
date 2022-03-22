using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ConfineCamera : MonoBehaviour
{
    private PolygonCollider2D _collider;
    private CinemachineConfiner _confiner;
    void Start()
    {
        _collider = GetComponent<PolygonCollider2D>();
        _confiner = GameObject.FindWithTag("VirtualCamera").GetComponent<CinemachineConfiner>();
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _confiner.m_BoundingShape2D = _collider;
        }
    }
}
