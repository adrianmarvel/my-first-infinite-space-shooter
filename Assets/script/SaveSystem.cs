using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem{
    
    public static void SavePlayer (Spacecraft spacecraft)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(spacecraft);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/player.save";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        

        } else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveHighscore (Highscore highscore)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/highscore.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        HighscoreClass data = new HighscoreClass(highscore);

        formatter.Serialize(stream, data);
        stream.Close();
    }

     public static HighscoreClass LoadHighscore ()
    {
        string path = Application.persistentDataPath + "/highscore.save";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HighscoreClass data = formatter.Deserialize(stream) as HighscoreClass;
            stream.Close();

            return data;
        

        } else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}
