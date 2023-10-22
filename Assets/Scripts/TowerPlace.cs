using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    public Sprite[] towers;
    public GameObject[] towersGameObject;
    private int index = 0;

    public bool equipped = false;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        spriteRenderer.sprite = towers[index];

        if (equipped)
        {
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousePosition;

        if(equipped && Input.GetMouseButtonDown(0))
        {
            equipped = false;
            Instantiate(towersGameObject[index], mousePosition, Quaternion.identity);
        }
    }
    public void place(int i)
    {
        equipped = true;
        index = i;
    }
}
