using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveData : MonoBehaviour
{
    public  static void SaveScore(int  score, string dataPath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + dataPath;

        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, score);
        stream.Close();
    }

    public static int LoadScore(string dataPath)
    {
        string path = Application.persistentDataPath + dataPath;

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode .Open);

            int score = (int)(formatter.Deserialize(stream) as int?);
            stream.Close();

            return score;
        }
        else
        {
            return 0;
        }
    }
    public static void SavePlayerUpgrades(PlayerUpgrades playerUpgrades)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "PlayerUpgrades";

        FileStream stream = new FileStream (path, FileMode .Create);
        formatter.Serialize(stream, playerUpgrades);
        stream.Close();
    }

    public static PlayerUpgrades LoadPlayerUpgrades()
    {
        string path = Application.persistentDataPath + "PlayerUpgrades";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerUpgrades playerUpgrades = formatter.Deserialize(stream) as PlayerUpgrades;
            stream.Close();
            return playerUpgrades;
        }
        else
        {
            return null;
        }
    }
}
