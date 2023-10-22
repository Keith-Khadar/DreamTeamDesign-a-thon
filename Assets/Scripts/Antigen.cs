using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antigen : MonoBehaviour
{
    private Transform virus;
    private CircleCollider2D circleCollider;
    private Rigidbody2D rb;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!virus)
        {
            circleCollider.radius += Time.deltaTime * speed;
        }
        else
        {
            circleCollider.radius = 0f;
            rb.AddForce((virus.position - transform.position).normalized * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Virus")
        {
            virus = collision.transform;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Virus")
        {
            Destroy(collision.gameObject);
            Spawner.current--;
            Destroy(gameObject);
        }
    }
}
