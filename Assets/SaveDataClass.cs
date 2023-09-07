using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveDataClass
{
    public int Health;
    public string Name;
    public Vector2 Position;
    public List<int> Test; 
   
}
[System.Serializable]

public class BinaryCompatiableSaveDataClass
{
    public int Health;
    public string Name;
    public float PositionX;
    public float PositionY;
    public List<int> Test;
}
