using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgressLocalSaver : PlayerProgressSaver
{
    private PlayerData _currentPlayerData;

    public override event Action Loaded;

    private void Awake()
    {
        _currentPlayerData = new();
        //_currentPlayerData.Count = 10;
        Loaded?.Invoke();
    }

    public override PlayerData GetPlayerData()
    {
        return _currentPlayerData;
    }

    public override void ResetSever()
    {
        _currentPlayerData = null;
    }

    public override void Save(PlayerData playerData)
    {
        _currentPlayerData = playerData;
    }
}
