using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem
{
    [System.Serializable]
    public class PlayerUpgrades
    {
        public int HealthUpgrade { get; set; }
        public float SpeedUpgrade { get; set; }
        public int DamageUpgrade { get; set; }

        public int[] ShopUpgradeLevels { get; set; }
    }

}