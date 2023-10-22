using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanBuy : MonoBehaviour
{
    public Button button;
    public int price;

    private void Update()
    {
        button.interactable = Score.Instance.canBuy(price);
    }

}
