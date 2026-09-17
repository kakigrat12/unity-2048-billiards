using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangugeChoserList : CurrentLanguge
{
    public override Languge Current => _languge;

    [SerializeField] private Languge _languge;
}
