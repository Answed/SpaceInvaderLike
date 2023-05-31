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
        public static void SavePlayerUpgrades(PlayerUpgrades upgrades)
        {
            var dir = Application.persistentDataPath + SaveDirectory;

            CreateJsonFile(dir + "PlayerUpgrades.txt", upgrades);
        }
        #region PlayerUpgrades
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
        }
        public static void SaveUpgradeShop(UpgradeShop upgradeShop)
        {
            var dir = Application.persistentDataPath + UpgradeDirectory;
            CheckIfDirectoryExist(dir);

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
