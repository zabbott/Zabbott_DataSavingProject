
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
 
public class SaveLoad : MonoBehaviour
{
    public SaveDataClass SaveData;
    public BinaryCompatiableSaveDataClass SaveDataBinaryInst; 
    public UIReadSaveData UIRS;
    private string Path;

    private void Start()
    {
        Path = string.Concat(Application.persistentDataPath, "/Data.json");
    }
    public void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("Health", SaveData.Health);
        PlayerPrefs.SetString("Name", SaveData.Name);
        PlayerPrefs.SetFloat("PositionX", SaveData.Position.x);
        PlayerPrefs.SetFloat("PositionY", SaveData.Position.y);
        PlayerPrefs.Save();
        UIRS.UpdateText(SaveData);
    }

    public void LoadPlayerPrefs()
    {
        SaveData.Health = PlayerPrefs.GetInt("Health", SaveData.Health);
        SaveData.Name = PlayerPrefs.GetString("Name", SaveData.Name);
        SaveData.Position = new Vector2(PlayerPrefs.GetFloat("PositionX", SaveData.Position.x),
          PlayerPrefs.GetFloat("PositionY", SaveData.Position.y));
        UIRS.UpdateText(SaveData);

    }

    public void SaveJson()
    {
        Debug.Log(Path);
        var stringifiedData = JsonUtility.ToJson(SaveData);
        if (File.Exists(Path))
        {
            File.WriteAllText(Path, stringifiedData);

        }
        else
        {
            File.Create(Path);
            File.WriteAllText(Path, stringifiedData);
        }
    }

    public void LoadJson()
    {
        if (File.Exists(Path))
        {
            string readText = File.ReadAllText(Path);
            SaveData = JsonUtility.FromJson<SaveDataClass>(readText);
            UIRS.UpdateText(SaveData);

        }

    }

    public void SaveBinary()
    {
        Debug.Log(Path);
        FileStream datastream = new FileStream(Path, FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(datastream, SaveDataBinaryInst);
        datastream.Close();
    }

    public void LoadBinary()
    {
        if (File.Exists(Path))
        {
            FileStream dataStream = new FileStream(Path, FileMode.Open);

            BinaryFormatter converter = new BinaryFormatter();
            SaveDataBinaryInst = converter.Deserialize(dataStream) as BinaryCompatiableSaveDataClass;

            dataStream.Close();
            UIRS.UpdateText(SaveDataBinaryInst);

        }
    }
}
