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

    private Vector2 forceDir;
    private float torqueDir;

    private float timeSinceLastDirectionChange;
    private bool runOnce = true;

    // Start is called before the first frame update
    void Start()
    {
        polarity_original = polarity;
        moveSpeed_original = moveSpeed;
        GetComponent<ParticleSystem>().Pause();
        rb = GetComponent<Rigidbody2D>();
        setMovement();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeSinceLastDirectionChange += Time.deltaTime;
        if (timeSinceLastDirectionChange >= changeDirectionInterval)
        {
            setMovement();
            timeSinceLastDirectionChange = 0.0f;
        }

        rb.AddForce(forceDir * moveSpeed * Time.deltaTime);
        rb.AddTorque(torqueDir * rotationSpeed * Time.deltaTime);

    }

    // Movement Types 
    void setMovement()
    {
        switch (movement) 
        {
            case 0:
                SetRandomDirection();
                break;
        }
    }
    void SetRandomDirection()
    {
        forceDir = new Vector2(Random.Range(-maxForce, maxForce), Random.Range(-maxForce, maxForce));
        torqueDir = Vector3.Cross(rb.velocity, forceDir).z;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Virus")
        {
            rb.AddForce((collision.transform.position - transform.position).normalized * polarity, ForceMode2D.Impulse);
            Vector3 offset = collision.transform.position - transform.position;

            if (runOnce)
            {
                StartCoroutine(lookat(offset));
            }
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
