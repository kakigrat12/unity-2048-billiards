using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameRestarter : MonoBehaviour
{
    public UnityEvent Restarted;

    public void Restart() => Restarted?.Invoke();
}
