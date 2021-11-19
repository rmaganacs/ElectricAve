using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void saveState(ClickScript src, Unlock progress)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/state.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveScript data = new SaveScript(src, progress);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveScript loadSate()
    {
        string path = Application.persistentDataPath + "/state.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveScript data = formatter.Deserialize(stream) as SaveScript;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
}
