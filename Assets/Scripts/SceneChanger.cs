using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void nextScene()
    {
        SceneManager.LoadScene(1);
    }
    public void menuScene()
    {
        SceneManager.LoadScene(0);
    }
}
