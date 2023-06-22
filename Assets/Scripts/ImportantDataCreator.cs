using SaveLoadSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class will be used to ensure that all Important files are created to ensure a smooth use of the game.
public class ImportantDataCreator : MonoBehaviour
{
    [SerializeField] private PlayerUpgrades playerUpgrades;
    [SerializeField] private UpgradeShop[] upgradeShopData; // Based on the settings made heere gets the data created for the actual shops.
    [SerializeField] private SettingsData settingsData;

    // Start is called before the first frame update
    void Start()
    {
        CreateUpgradeShopFiles();
        CreatePlayerUpgradeFile();
        CreateSettingsFile();
    }

    private void CreateUpgradeShopFiles()
    {
        foreach(UpgradeShop upgradeShop in upgradeShopData)
        {
            SaveLoadSystem.SaveSystemManager.CreateUpgradeShop(upgradeShop);
        }
    }

    private void CreatePlayerUpgradeFile()
    {
        SaveLoadSystem.SaveSystemManager.CreatePlayerUpgrades(playerUpgrades);
    }

    private void CreateSettingsFile()
    {
        SaveLoadSystem.SaveSystemManager.CreateSettings(settingsData);
    }

}
