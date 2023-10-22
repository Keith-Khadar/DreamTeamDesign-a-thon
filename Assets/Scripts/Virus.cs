using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Virus : MonoBehaviour
{
    Transform target;
    Rigidbody2D rb;
    public float speed;

    public GameObject explosion;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Exit").transform;
    }

    void Update()
    {
        // Move the virus towards the target
        rb.AddForce((target.position - transform.position).normalized * speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If it hits a cell lower the cells health and destory the virus
        if(collision.tag == "Vulnerable" && collision.GetComponent<Infected>().health > 0)
        {
            collision.GetComponent<Infected>().health--;

            explosion.SetActive(true);
            Spawner.current--;
            Destroy(this.gameObject);
        }

        // If it is near a cell set the transform to be the cell and move towards it
        if(collision.tag == "Boundary")
        {
            if(collision.GetComponentInParent<Infected>().health <= 0)
            {
                return;
            }
            target = collision.transform;

            // Slow the virus down and then make it speed up towards the cell
            rb.velocity /= 5;
            speed *= 3;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            Spawner.current--;
            Destroy(this.gameObject);
        }
    }
}
