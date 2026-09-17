using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int Count;
}

public abstract class PlayerProgressSaver : MonoBehaviour
{
    public abstract event Action Loaded;

    public abstract void Save(PlayerData playerData);
    public abstract void ResetSever();
    public abstract PlayerData GetPlayerData();
}
