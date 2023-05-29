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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadPoints()
    {
        points = SaveLoadSystem.SaveSystemManager.LoadScore();
        pointText.text = "Points: " + points;
    }

    public void SavePoints()
    {
        SaveLoadSystem.SaveSystemManager.SaveScore(points);
    }

    public void UpgradeHealth()
    {
        if (CheckLevel(0))
        {
            EnoughPoints(upgradeShops[0].currentPrice, 0);
            currentUpgrade = Upgrades.Health;
        }
        else Debug.Log("Max Level");
    }

    private bool CheckLevel(int shopIndex)
    {
        if (upgradeShops[shopIndex].currentLevel == upgradeShops[shopIndex].Level.Last())
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
            UpdateShop(shopIndex);
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

    private void UpdateShop(int index)
    {
        upgradeShops[index].currentLevel = index;
        upgradeShops[index].currentPrice = upgradeShops[index].Prices[index];
    }
}
