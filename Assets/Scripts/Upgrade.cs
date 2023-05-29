using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    public int currentLevel;
    public int currentPrice;
    public int[] Level;
    public int[] Prices;
    public TextMeshProUGUI priceText;

    public void UpdateCosts()
    {
        priceText.text = currentPrice.ToString();
    }
}
