using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SmallestBallRemover : MonoBehaviour
{
    public void Remove(int count = 2)
    {
        var levels = transform.GetComponentsInChildren<Ball>();
        var ordered = levels.OrderBy(x => x.Level.GetValue()).ToList();

        for (int i = 0; i < Mathf.Min(count, ordered.Count); i++)
        {
            ordered[i].Remover.Remove();
        }
    }
}
