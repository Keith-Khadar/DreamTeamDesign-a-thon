using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public float currentScore = 0;
    public float time = 0;
    public int ATP = 5;
    public float immunity = 0;

    private void Start()
    {
        if (Difficulty.RomanButton)
        {
            ATP = 0;
        }
    }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        currentScore += Time.deltaTime;
        time += Time.deltaTime;

        if (time > 14)
        {
            if(!Difficulty.RomanButton) 
            {
                ATP += 16;
            }
            else
            {
                ATP += 8;
            }
            
            time = 0;
        }

    }

    public bool canBuy(int cost)
    {
        if(ATP >= cost)
        {
            return true;
        }
        return false;
    }
    public void buy(int cost)
    {
        ATP -= cost;
    }
}
