using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawn : MonoBehaviour
{
    public float lifeTime;
    public GameObject explosion;

    private void Start()
    {
        StartCoroutine(death(lifeTime));
    }

    IEnumerator death(float lifetime)
    {
        if (Difficulty.RomanButton)
        {
            lifetime /= 2;
        }
        yield return new WaitForSeconds(lifetime);
        if(gameObject.tag == "Virus")
        {
            Spawner.current--;
        }
        if(gameObject.tag == "Antibodies")
        {
            Spawner.currentAnti--;
        }
        if(explosion != null)
        {
            explosion.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(1f);
        }

        Destroy(gameObject);

    }
}
