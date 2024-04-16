using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Data
{

    private static Data data = null;

    private Data()
    {

    }

    public static Data GetInstance
    {
        get {
            if (data == null)
            {
                data = new Data();
            }
            return data; 
        }
    }

    private static List<WorldGenerationSetup> generationSetups = new List<WorldGenerationSetup>();

    public WorldGenerationSetup currentWorldGenerationSetup { get; set; }
    public List<WorldGenerationSetup> GetWorldGenerationSetups() 
    { 
        return generationSetups; 
    }

    public void AddToGenerationSetupList(WorldGenerationSetup wgs)
    {
        generationSetups.Add(wgs);
    }

    public void SaveGenerationSetups()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/generationSetups.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, generationSetups);
        stream.Close();
    }

    public void LoadGenerationSetups()
    {
        string path = Application.persistentDataPath + "/generationSetups.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            generationSetups = formatter.Deserialize(stream) as List<WorldGenerationSetup>;
            stream.Close();
        }
        else
        {
            Debug.LogWarning("Save file not found.");
        }
    }
}
