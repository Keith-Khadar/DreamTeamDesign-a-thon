using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infected : MonoBehaviour
{
    public float health = 100f;
    private float startHealth;

    public GameObject spawner;

    private Color originalColor;


    private void Start()
    {
        originalColor = GetComponent<SpriteRenderer>().color;
        startHealth = health;
    }
    void Update()
    {
        if(health < 0)
        {
            spawner.SetActive(true);
            GetComponent<SpriteRenderer>().color = Color.black;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(originalColor, Color.green, (startHealth - health) / startHealth);
        }

    }
}
