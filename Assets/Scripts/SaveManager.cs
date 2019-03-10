using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static  class SaveManager{

	public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerdata.dat";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

        PlayerProgress data = new PlayerProgress(player);
        Debug.Log("saving THIS MONEY " + data.coinsAmount);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerProgress LoadPlayer()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerdata.dat";
        FileStream stream = new FileStream(path, FileMode.Open);

        PlayerProgress progress = formatter.Deserialize(stream) as PlayerProgress;
        Debug.Log("LOADING PROGRESS " + progress.coinsAmount);
        stream.Close();
        return progress;

    }
        
}
