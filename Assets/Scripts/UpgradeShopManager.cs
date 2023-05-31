using SaveLoadSystem;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TMPro;
using UnityEngine;

public class UpgradeShopManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private UpgradeShop[] upgradeShops;

    private int points;

    private PlayerUpgrades playerUpgrades;

    enum Upgrades
    {
        Health,
        Speed,
        Damage
    }

    private Upgrades currentUpgrade;

    public void LoadShop()
    {
        LoadPoints();
        LoadUpgradeShops();
    }

    public void CloseShop()
    {
        SaveLoadSystem.SaveSystemManager.SaveScore(points);
    }

    private void LoadPoints()
    {
        points = SaveLoadSystem.SaveSystemManager.LoadScore();
        pointText.text = "Points: " + points;
    }

    private void LoadUpgradeShops()
    {
        upgradeShops = SaveLoadSystem.SaveSystemManager.LoadUpgradeShop();

        for(int i = 0; i < upgradeShops.Length; i++)
        {
            UpdateShop(i, 0);
        }
    }

    public void UpgradeHealth()
    {
        if (CheckLevel(0))
        {
            EnoughPoints(upgradeShops[0].Prices[upgradeShops[0].currentLevel], 0);
            currentUpgrade = Upgrades.Health;
        }
        else Debug.Log("Max Level");
    }

    public void UpgradeArmor()
    {
        if (CheckLevel(1))
        {
            EnoughPoints(upgradeShops[1].Prices[upgradeShops[1].currentLevel], 1);
            currentUpgrade = Upgrades.Health;
        }
        else Debug.Log("Max Level");
    }

    public void UpgradeSpeed()
    {
        if (CheckLevel(2))
        {
            EnoughPoints(upgradeShops[2].Prices[upgradeShops[2].currentLevel], 2);
            currentUpgrade = Upgrades.Speed;
        }
        else Debug.Log("Max Level");
    }

    public void UpgradeDamage()
    {
        if (CheckLevel(3))
        {
            EnoughPoints(upgradeShops[3].Prices[upgradeShops[3].currentLevel], 3);
            currentUpgrade = Upgrades.Damage;
        }
        else Debug.Log("Max Level");
    }

    private bool CheckLevel(int shopIndex)
    {
        if (upgradeShops[shopIndex].currentLevel == upgradeShops[shopIndex].maxLevel)
        {
            upgradeShops[shopIndex].priceText.text = "Max Level";
            return false;
        }
        else return true;
    }

    private bool EnoughPoints(int neededPoints, int shopIndex)
    {
        if (points >= neededPoints)
        {
            points -= neededPoints;
            UpgradeStats();
            UpdateShop(shopIndex, 1);
            return true;
        }
        else
        {
            Debug.Log("Not Enough Points");
            return false;
        }
    }

    private void UpgradeStats()
    {
        switch(currentUpgrade)
        {
            case Upgrades.Health:
                playerUpgrades.HealthUpgrade += 1;
                break;
            case Upgrades.Speed:
                playerUpgrades.SpeedUpgrade += 0.5f;
                break;
            case Upgrades.Damage:
                playerUpgrades.DamageUpgrade += 1;
                break;
        }
    }

    private void UpdateShop(int index, int newLevel)
    {
        upgradeShops[index].currentLevel = index;
        upgradeShops[index].priceText.text = upgradeShops[index].Prices[upgradeShops[index].currentLevel].ToString();

        SaveLoadSystem.SaveSystemManager.SaveUpgradeShop(upgradeShops[index]);
    }
}
