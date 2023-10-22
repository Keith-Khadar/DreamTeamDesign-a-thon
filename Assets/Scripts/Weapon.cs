using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float height = Mathf.Lerp(0f, 4f, currentTime);
        GetComponent<CapsuleCollider2D>().offset = new Vector2(0, height);
        currentTime += Time.deltaTime;
    }
}
