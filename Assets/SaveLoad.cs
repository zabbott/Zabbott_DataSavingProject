using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public SaveDataClass SaveData;
    public UIReadSaveData UIRS;
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
}
