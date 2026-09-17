using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettableLevel : Level
{
    public void SetLevel(int value)
    {
        SetValue(value - 1);
        LevelUp();
    }
}
