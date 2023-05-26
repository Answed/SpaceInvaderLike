using System.IO;
using UnityEngine;

namespace SaveLoadSystem
{
    public static class SaveSystemManager
    {
        public const string SaveDirectory =  "/SaveData/";

        public static void SaveScore(int newScore)
        {
            var dir = Application.persistentDataPath + SaveDirectory;

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string json = JsonUtility.ToJson(newScore, true);
            File.WriteAllText(dir + "Score.txt", json); //Filename can be hard coded bc i always refer to that file
        }

        public static int LoadScore()
        {
            var fullPath = Application.persistentDataPath + SaveDirectory + "Score.txt";

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                var score = JsonUtility.FromJson<int>(json); 
                return score;
            }
            else // When the user loads the Shop for the first time we create the Score File which has a value of 0 because the player never has played the game.
            {
                SaveScore(0);
                return 0;
            }
        }
    }
}
