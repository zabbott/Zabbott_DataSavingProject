using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//THIS IS THE VIEW SCRIPT IN MVC
public class UIReadSaveData : MonoBehaviour
{
    public TMP_InputField NameText;
    public TMP_InputField HealthText;
    public TMP_InputField PositionText;
    public TMP_InputField PositionYText;

    public SaveLoad SaveLoad;


    public bool UsePPE;
    public bool UseJSON;
    public bool UseBinary;
    public void UpdateText(SaveDataClass svc)
    {
        NameText.text = svc.Name;
        HealthText.text = svc.Health.ToString();
        PositionText.text = svc.Position.x.ToString();
        PositionYText.text = svc.Position.y.ToString();

    }
    public void UpdateText(BinaryCompatiableSaveDataClass svc)
    {
        NameText.text = svc.Name;
        HealthText.text = svc.Health.ToString();
        PositionText.text = svc.PositionX.ToString();
        PositionYText.text = svc.PositionY.ToString();

    }
    public void UpdateSaveData()
    {
        SaveLoad.SaveData.Name = NameText.text;
        SaveLoad.SaveData.Health = int.Parse(HealthText.text);
        SaveLoad.SaveData.Position = new Vector2(int.Parse(PositionText.text), int.Parse(PositionYText.text));
        SaveLoad.SavePlayerPrefs();
    }


    public void SaveWithJson()
    {
        SaveLoad.SaveData.Name = NameText.text;
        SaveLoad.SaveData.Health = int.Parse(HealthText.text);
        SaveLoad.SaveData.Position = new Vector2(int.Parse(PositionText.text), int.Parse(PositionYText.text));
        SaveLoad.SaveJson();
    }

    public void SaveWithBson()
    {
        SaveLoad.SaveDataBinaryInst.Name = NameText.text;
        SaveLoad.SaveDataBinaryInst.Health = int.Parse(HealthText.text);
        SaveLoad.SaveDataBinaryInst.PositionX = int.Parse(PositionText.text);
        SaveLoad.SaveDataBinaryInst.PositionY = int.Parse(PositionYText.text);

        SaveLoad.SaveBinary();
    }
}
