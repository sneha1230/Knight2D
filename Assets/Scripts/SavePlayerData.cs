using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SavePlayerData : MonoBehaviour
{
    public string playerName;
    public int playerAge;
    public string playerLocation;


    // Update is called once per frame
    void Update()
    {
        SetData();
        GetData();
    }
    public void SetData()
    {
        string path = Application.persistentDataPath + "/PlayerData.file";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        BinaryWriter writer = new BinaryWriter(stream);
        formatter.Serialize(stream, playerName);
        formatter.Serialize(stream, playerAge);
        formatter.Serialize(stream, playerLocation);
        stream.Close();
    }
    public void GetData()
    {
        string path = Application.persistentDataPath + "/PlayerData.file";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        formatter.Deserialize(stream);
        stream.Close();
    }
}
