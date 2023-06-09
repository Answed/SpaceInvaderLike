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
    public struct UpgradeShop
    {
        public string Name;
        public int currentLevel;
        public int maxLevel;
        public int[] Prices;
    }
    [System.Serializable]
    public class SettingsData
    {
        public float musicVolume;
        public float effectsVolume;
    }
}