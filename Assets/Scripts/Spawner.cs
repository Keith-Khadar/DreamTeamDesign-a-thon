using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform center;
    public Transform edge;
    private float dist;
    private Vector2 dir;

    public GameObject enity;

    public float rate;
    private float currentTime = 0;

    public static float max = 100;
    public static float current = 0;


    private Vector2 spawnloc;
    private GameObject instantiated;

    // Update is called once per frame
    private void Start()
    {
        if(edge != null)
        {
            dist = Vector2.Distance(center.position, edge.position);
            dir = (edge.position - center.position).normalized;
        }
    }

    void Update()
    {
        if(currentTime > rate && current < max)
        {
            if(edge == null)
            {
                instantiated = Instantiate(enity, center.position, Quaternion.identity, transform);
            }
            else
            {
                spawnloc =  (Vector2)center.position + ( dir * Random.Range(-dist, dist));
                instantiated = Instantiate(enity, spawnloc, Quaternion.identity, transform);
            }

            // Spawn in with random velocity
            instantiated.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f)), ForceMode2D.Impulse);
            current++;
            currentTime = 0;
        }

        currentTime += Time.deltaTime;
    }
}
