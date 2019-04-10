using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveLives(PizzaBoyController player)
    {
        //makes file binary
        BinaryFormatter formatter = new BinaryFormatter();
        //stores file to a consistent location
        string path = Application.persistentDataPath + "/player.txt";
        //creates new file
        FileStream stream = new FileStream(path, FileMode.Create);
        //collects data
        PlayerData data = new PlayerData(player);
        //writes data to file
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.LogError("Saved lives");
    }

    public static void SaveAmmo(PizzaBoyController player)
    {
        //makes file binary
        BinaryFormatter formatter = new BinaryFormatter();
        //stores file to a consistent location
        string path = Application.persistentDataPath + "/ammo.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        //collects data
        PlayerData data = new PlayerData(player);
        //writes data to file
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.LogError("Saved ammo");
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.txt";
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
            Debug.LogError("Save not found " + path);
            return null;
        }


    }

    public static PlayerData LoadAmmo()
    {
        string path = Application.persistentDataPath + "/ammo.txt";
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
            Debug.LogError("Save not found " + path);
            return null;
        }
    }
}
