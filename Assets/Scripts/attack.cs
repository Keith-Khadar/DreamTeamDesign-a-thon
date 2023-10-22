using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float currentTime = 0;

    public GameObject weapon;


    // Update is called once per frame
    void Update()
    {
        if(currentTime > attackSpeed)
        {
            Instantiate(weapon, transform.position, transform.rotation);
            currentTime = 0;
        }
        currentTime += Time.deltaTime;
    }
}
