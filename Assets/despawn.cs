using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawn : MonoBehaviour
{
    public float lifeTime;

    private void Start()
    {
        StartCoroutine(death(lifeTime));
    }

    IEnumerator death(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
