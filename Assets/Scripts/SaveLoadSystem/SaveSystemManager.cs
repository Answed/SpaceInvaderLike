using System.IO;
using UnityEngine;

namespace SaveLoadSystem
{
    public static class SaveSystemManager
    {
        public const string SaveDirectory =  "/SaveData/";
        
        public static void SaveScore(int score)
        {
            var dir = Application.persistentDataPath + SaveDirectory;
            CheckIfDirectoryExist(dir);

            Score currentScore = new Score();
            currentScore.score = score;

            string json = JsonUtility.ToJson(currentScore, true);
            File.WriteAllText(dir + "Score.txt", json); //Filename can be hard coded bc i always refer to that file
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

        public static void CheckIfDirectoryExist(string DirectoryPath)
        {
            if (!Directory.Exists(DirectoryPath))
                Directory.CreateDirectory(DirectoryPath);
        }
    }
}
