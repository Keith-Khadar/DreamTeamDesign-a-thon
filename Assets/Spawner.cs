using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform regionLL;
    public Transform regionUR;
    public GameObject enity;

    public float rate;
    private float currentTime = 0;

    private Vector2 spawnloc;


    // Update is called once per frame
    void Update()
    {
        if(currentTime > rate)
        {
            spawnloc = new Vector2(regionLL.position.x + ((regionUR.position.x - regionLL.position.x) * Random.Range(0f, 1f)),
                regionLL.position.y + ((regionUR.position.y - regionLL.position.y) * Random.Range(0f, 1f)));
            Instantiate(enity, spawnloc, Quaternion.identity,transform);
            currentTime = 0;
        }

        currentTime += Time.deltaTime;
    }
}
