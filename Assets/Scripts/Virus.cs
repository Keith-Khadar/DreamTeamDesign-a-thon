using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Virus : MonoBehaviour
{
    Transform target;
    Rigidbody2D rb;
    public float speed;
    public float orbitForce;
    public float orbitDist;

    public GameObject explosion;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Get the closest target
        target = VulnerableCells.singleton.cells[0];

        foreach (Transform t in VulnerableCells.singleton.cells)
        {
            if(Vector3.Distance(transform.position, t.position) < Vector3.Distance(transform.position, target.position))
            {
                target = t;
            }
        }

        rb.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)), ForceMode2D.Impulse);
    }

    void Update()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        float distance = Vector2.Distance(target.position, transform.position);

        Debug.Log(distance);
        if(distance > orbitDist)
        {
            rb.AddForce(direction * speed * Time.deltaTime);
        }
        else
        {
            rb.AddForce(direction * (orbitForce / Mathf.Pow(distance, 2)) * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Vulnerable")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
