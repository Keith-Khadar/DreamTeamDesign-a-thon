using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class targeting : MonoBehaviour
{
    public float movement = 0; // 0 Random, 

    public float polarity = 1;
    private float polarity_original;

    private float moveSpeed_original;
    public float moveSpeed = 1.0f;
    public float rotationSpeed = 45.0f;
    public float maxForce = 0.1f;

    public float changeDirectionInterval = 1.0f;

    private Rigidbody2D rb;

    public Transform closestVirus;
    public Transform closestWall;
    public Transform closestCell;

    private Vector2 forceDir;
    private Vector2 polarityDir;
    private float torqueDir;

    private float timeSinceLastDirectionChange;
    private bool runOnce = true;

    // Start is called before the first frame update
    void Start()
    {
        polarity_original = polarity;
        moveSpeed_original = moveSpeed;
        rb = GetComponent<Rigidbody2D>();


        SetRandomDirection();


        if (movement == 0) 
        {
            GetComponent<ParticleSystem>().Stop();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeSinceLastDirectionChange += Time.deltaTime;
        if (timeSinceLastDirectionChange >= changeDirectionInterval)
        {
            SetRandomDirection();
            setTargetDirection();
            timeSinceLastDirectionChange = 0.0f;
        }

        rb.AddForce(forceDir * moveSpeed * Time.deltaTime);
        rb.AddTorque(torqueDir * rotationSpeed * Time.deltaTime);

        rb.AddForce(polarityDir * polarity * Time.deltaTime);

    }

    // Movement Types 
    void SetRandomDirection()
    {
        forceDir = new Vector2(Random.Range(-maxForce, maxForce), Random.Range(-maxForce, maxForce));
        torqueDir = Vector3.Cross(rb.velocity, forceDir).z;
    }
    void setTargetDirection()
    {
        polarityDir = Vector2.zero;
        switch (movement)
        {
            case 0: // Regular attaker
                if(closestVirus)
                {
                    polarityDir += (Vector2)(closestVirus.position - transform.position).normalized;
                    if (runOnce) { StartCoroutine(lookat(closestVirus.position - transform.position)); }
                }
                    
                    
                break;
            case 1: // Support 
                if (closestCell)
                {
                    polarityDir += (Vector2)(closestCell.position - transform.position).normalized;
                    if (runOnce) { StartCoroutine(lookat(closestCell.position - transform.position)); }
                }
                break;
        }
        if(closestWall)
            polarityDir += (Vector2)(transform.position - closestWall.position).normalized;
    }

    // Kill Virus
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Virus")
        {
            Spawner.current--;
            Destroy(collision.gameObject);
            rb.velocity = Vector2.zero;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Virus")
        {
            closestVirus = collision.transform;
        }
        if (collision.gameObject.tag == "ImmuneCell")
        {
            closestCell = collision.transform;
        }
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Exit")
        {
            if(Vector2.Distance(transform.position, collision.transform.position) < 2.5f)
                closestWall = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Virus")
        {
            closestVirus = null;
        }
        if (collision.gameObject.tag == "ImmuneCell")
        {
            closestCell = null;
        }
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Exit")
        {
            closestWall = null;
        }
    }

    IEnumerator lookat(Vector3 offest)
    {
        runOnce = false;
        float timeElapsed = 0;
        while (timeElapsed < 2f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, offest), timeElapsed / 2f);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        runOnce = true;
    }

    public void resetEffects()
    {
        polarity = polarity_original;
        moveSpeed = moveSpeed_original;
    }



}
