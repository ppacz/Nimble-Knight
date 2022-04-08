using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//this class handles saving and loading players info in games folder in binary file
public static class SaveSystem
{
    public static void SavePlayer(GameObject Player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.goy";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(Player);

        formatter.Serialize(stream, data);
        Debug.Log(path);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/save.goy";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Game save had to be deleted.\n file should be located here: " + path);
            return null;
        }
    }

}
