using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Support : MonoBehaviour
{


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "ImmuneCell")
        {
            collision.GetComponent<targeting>().polarity = 0.25f;
            collision.GetComponent<targeting>().moveSpeed *= 2f;
            collision.GetComponent<ParticleSystem>().Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ImmuneCell")
        {
            collision.GetComponent<targeting>().resetEffects();
            collision.GetComponent<ParticleSystem>().Pause();

        }
    }
}
