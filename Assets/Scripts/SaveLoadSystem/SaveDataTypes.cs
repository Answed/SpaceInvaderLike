using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SaveLoadSystem
{
    [System.Serializable]
    public class PlayerUpgrades
    {
        public int HealthUpgrade;
        public float SpeedUpgrade;
        public int DamageUpgrade;
        public int ArmorUpgrades;
    }

    [System.Serializable]
    public class Score
    {
        public int score;
    }

    [System.Serializable]
    public class UpgradeShop : MonoBehaviour
    {
        public string Name;
        public int currentLevel;
        public int currentPrice;
        public int[] Level;
        public int[] Prices;
        public TextMeshProUGUI priceText;

    }
}