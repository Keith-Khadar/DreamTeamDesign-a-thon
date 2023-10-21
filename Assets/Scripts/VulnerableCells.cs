using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VulnerableCells : MonoBehaviour
{
    public Transform[] cells;

    public static VulnerableCells singleton;

    private void Awake()
    {
        if(singleton != null && singleton != this)
        {
            Destroy(this);
        }
        else
        {
            singleton = this;
        }
    }
}

