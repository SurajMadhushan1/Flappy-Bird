using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject prefab;
    public float minheight = -1f;
    public float maxheight = 1f;
    public float spawnRate = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(spawn));
    }

    private void spawn()
    {
        GameObject pipes = Instantiate(prefab , transform.position,Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minheight,maxheight);
    }

}
