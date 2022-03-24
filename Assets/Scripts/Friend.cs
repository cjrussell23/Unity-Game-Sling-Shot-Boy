using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Friend: MonoBehaviour
{
    private Canvas _canvas;
    private bool _inEnd;

    void Start()
    {
        _canvas = gameObject.transform.GetChild(0).GetComponent<Canvas>();
        Invoke(nameof(DisableCanvas), 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool _hasGems = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().HasGems();
        if (collision.gameObject.CompareTag("Player") && _inEnd && _hasGems)
        {
            Debug.Log("Game Over");
            _canvas.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Text>().text = "You found them all! Thank you <3";
            _canvas.enabled = true;

        }
        else
        {
            _canvas.enabled = true;
            Invoke(nameof(DisableCanvas), 5);
        }
    }
    void DisableCanvas()
    {
        _canvas.enabled = false;
    }
    public void Move()
    {
        transform.position = new Vector3(19.5f, -26f, 0f);
        _inEnd = true;
    }
}
