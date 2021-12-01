using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void saveState(ClickScript src, Unlock progress)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/sate.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveScript data = new SaveScript(src, progress);

        formatter.Serialize(stream, data);
        stream.Close();
    }
}
