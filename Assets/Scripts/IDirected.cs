using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDirected
{
    public void Direct(Vector3 direction, float partOfMaxDistance);

    void CheckIndexOutOfRange(float partOfMaxDistance)
    {
        if (partOfMaxDistance < 0 || partOfMaxDistance > 1)
            throw new IndexOutOfRangeException();
    } 
}
