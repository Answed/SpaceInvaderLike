using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SaveLoadSystem
{
    public static class SaveSystemManager
    {
        public const string SaveDirectory =  "/SaveData/";
        public const string UpgradeDirectory = SaveDirectory + "/Upgrades/";

        #region Score
        public static void SaveScore(int score)
        {
            var dir = Application.persistentDataPath + SaveDirectory;
            CheckIfDirectoryExist(dir);

            Score currentScore = new Score();
            currentScore.score = score;

            CreateJsonFile(dir + "Score.txt", currentScore);
        }

        public static int LoadScore()
        {
            var fullPath = Application.persistentDataPath + SaveDirectory + "Score.txt";

            GUIUtility.systemCopyBuffer = Application.persistentDataPath + SaveDirectory;

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                Score currentScore = JsonUtility.FromJson<Score>(json); 
                return currentScore.score;
            }
            else // When the user loads the Shop for the first time we create the Score File which has a value of 0 because the player never has played the game.
            {
                SaveScore(0);
                return 0;
            }
        }
        #endregion
        #region PlayerUpgrades
        public static void CreatePlayerUpgrades(PlayerUpgrades playerUpgrades)
        {
            var dir = Application.persistentDataPath + SaveDirectory;
            CheckIfDirectoryExist(dir);

            if (!File.Exists(dir + "PlayerUpgrades.txt")) // This is needed to prevent overwriting everytime the game is started
                CreateJsonFile(dir + "PlayerUpgrades.txt", playerUpgrades);
        }
        public static void SavePlayerUpgrades(PlayerUpgrades upgrades)
        {
            var dir = Application.persistentDataPath + SaveDirectory;

            CreateJsonFile(dir + "PlayerUpgrades.txt", upgrades);
        }
        public static PlayerUpgrades LoadPlayerUpgrades()
        {
            var fullPath = Application.persistentDataPath + SaveDirectory + "PlayerUpgrades.txt";
            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                PlayerUpgrades playerUpgrades = JsonUtility.FromJson<PlayerUpgrades>(json);
                return playerUpgrades;
            }
            else { return null; }
        }
        #endregion
        #region UpgradeShops

        public static void CreateUpgradeShop(UpgradeShop upgradeShop) //Creates all missing shops after first start up, when a shop gets deleted or a new one is added to the game.
        {
            var dir = Application.persistentDataPath + UpgradeDirectory;
            CheckIfDirectoryExist(dir);

            if(!File.Exists(dir + upgradeShop.Name))
                CreateJsonFile(dir + upgradeShop.Name, upgradeShop);

            GUIUtility.systemCopyBuffer = dir;
        }
        public static void SaveUpgradeShop(UpgradeShop upgradeShop)
        {
            var dir = Application.persistentDataPath + UpgradeDirectory;
            CreateJsonFile(dir + upgradeShop.Name, upgradeShop);
        }
        public static UpgradeShop[] LoadUpgradeShop()
        {
            var fullPath = Application.persistentDataPath + UpgradeDirectory;
            var upgradeFiles = Directory.GetFiles(fullPath);
            List<UpgradeShop> data = new List<UpgradeShop>();
            if (upgradeFiles.Length > 0)
            {
                foreach (var file in upgradeFiles)
                {
                    string json = File.ReadAllText(file);
                    data.Add(JsonUtility.FromJson<UpgradeShop>(json));
                }
                return data.ToArray();
            }
            else { return null; }
        }
        #endregion
        #region Settings
        public static void CreateSettings(SettingsData settingsData)
        {
            var dir = Application.persistentDataPath + SaveDirectory;
            CheckIfDirectoryExist(dir);

            if(!File.Exists(dir + "Settings"))// This is needed to prevent overwriting everytime the game is started
                CreateJsonFile(dir + "Settings", settingsData);
        }
        public static void SaveSettings(SettingsData settingsData)
        {
            var dir = Application.persistentDataPath + SaveDirectory;

            CreateJsonFile(dir + "Settings", settingsData);
        }
        public static SettingsData LoadSettings()
        {
            var fullPath = Application.persistentDataPath + SaveDirectory + "Settings";
            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                SettingsData settingsData = JsonUtility.FromJson<SettingsData>(json);
                return settingsData;
            }
            else { return null; }
        }

        #endregion
        public static void CheckIfDirectoryExist(string DirectoryPath)
        {
            if (!Directory.Exists(DirectoryPath))
                Directory.CreateDirectory(DirectoryPath);
        }

        private static void CreateJsonFile<T>(string Fullpath,T data)
        {
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(Fullpath, json);
        }
    }
}
