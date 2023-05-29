using System.IO;
using UnityEngine;

namespace SaveLoadSystem
{
    public static class SaveSystemManager
    {
        public const string SaveDirectory =  "/SaveData/";
        public const string UpgradeDirectory = SaveDirectory + "/Upgrades/";


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

        public static void SaveUpgradeShop(UpgradeShop upgradeShop)
        {
            var dir = Application.persistentDataPath + UpgradeDirectory;
            CheckIfDirectoryExist(dir);

            CreateJsonFile(dir + upgradeShop.Name, upgradeShop);
        }

        public static UpgradeShop LoadUpgradeShop(string nameOfShop)
        {
            var fullPath = Application.persistentDataPath + UpgradeDirectory + nameOfShop;
            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                UpgradeShop upgradeShop = JsonUtility.FromJson<UpgradeShop>(json);
                return upgradeShop;
            }
            else { return null; }
        }

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
