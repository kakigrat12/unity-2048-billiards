using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsRemover : MonoBehaviour
{
    public void Remove()
    {
        foreach (var remover in GetRemoversFromChildren())
            remover.Remove();
    }

    private Remover[] GetRemoversFromChildren()
        => GetComponentsInChildren<Remover>();
}
