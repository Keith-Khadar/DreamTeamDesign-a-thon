using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImmunityLevel : MonoBehaviour
{
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        slider.value = Score.Instance.immunity;

        if(slider.value == 1)
        {
            SceneManager.LoadScene(3);
        }
    }
}
