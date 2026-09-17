using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerProgressYandexSaver : PlayerProgressSaver
{
    private PlayerData _playerData = new();

    [DllImport("__Internal")]
    private static extern void RateGame();

    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    [DllImport("__Internal")]
    private static extern void SetDataToLiderboard(int number);

    public override event Action Loaded;

    
    private void Start()
    {
        Debug.Log("LoadExtern");
        LoadExtern();
    }
    

    public override PlayerData GetPlayerData()
    {
        return _playerData;
    }

    public override void ResetSever()
    {
        Save(new PlayerData());
    }

    public override void Save(PlayerData playerData)
    {
        _playerData = playerData;
        string json = JsonUtility.ToJson(_playerData);
        SaveExtern(json);

        //SetToLidearboard(_playerData.Count);
    }

    public void SetToLidearboard()
    {
        Debug.Log("SetToLidearboard 0 Unity");
        SetDataToLiderboard(_playerData.Count);
    }



    public void SetPlayerDataServer(string value)
    {
        _playerData = JsonUtility.FromJson<PlayerData>(value);
        Loaded?.Invoke();
        Debug.Log("Loaded");

        SetToLidearboard();
    }
}
