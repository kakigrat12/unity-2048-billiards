using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CurrentLanguge : MonoBehaviour
{
    public enum Languge { ru, en };
    public abstract Languge Current { get; }

    public static CurrentLanguge Instance;

    private void OnEnable()
    {
        Instance = this;
    }
}