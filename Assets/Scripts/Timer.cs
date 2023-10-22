using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI textMeshPro;

    // Update is called once per frame
    void Update()
    {
        //Calculate the time in minutes and seconds.
        int seconds = (14 - (int)Score.Instance.time) % 60;

        //Update the duration text.
        textMeshPro.text = ((seconds < 10) ? ("0") : ("")) + seconds.ToString();
    }
}
