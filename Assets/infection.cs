using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class infection : MonoBehaviour
{
    public static float infectionAmount = 0f;

    private Color startColor;

    private void Start()
    {
        startColor = GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        Debug.Log(infectionAmount);
        if (infectionAmount >= 0.99f) 
        {
            SceneManager.LoadScene(2);
        }

        GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, Color.green, infectionAmount);
    }
}
