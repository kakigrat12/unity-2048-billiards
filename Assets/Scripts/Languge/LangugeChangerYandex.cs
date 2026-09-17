using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class LangugeChangerYandex : CurrentLanguge
{
    [DllImport("__Internal")]
    private static extern string GetLang();

    private Languge _current;

    public override Languge Current => _current;

    private void Awake()
    {
        UpdateLang();
    }

    private void UpdateLang()
    {
        switch (GetLang())
        {
            case "ru":
                _current = Languge.ru;
                break;
            case "en":
                _current = Languge.en;
                break;
        }
    }
}
