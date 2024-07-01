using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;

    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 5f;
    }


    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= leftEdge)
        {
            Destroy(gameObject);
        }

    }
}
