using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkBackgroundColors : MonoBehaviour
{
    [SerializeField] private Color[] colors;

    public Color PerkBackgroundColor(int rarity)
    {
        switch (rarity)
        {
            case 5: return colors[0];
            case 3: return colors[2];
            case 1: return colors[4];
            default: return colors[0];
        }
    }

    public Color PerkBackgroundHighlightedColor(int rarity)
    {
        switch (rarity)
        {
            case 5: return colors[1];
            case 3: return colors[3];
            case 1: return colors[5];
            default: return colors[1];
        }
    }
}
