using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ATP : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    // Update is called once per frame
    void Update()
    {
        //Update the duration text.
        textMeshPro.text = "ATP: " + Score.Instance.ATP.ToString();
    }
}
