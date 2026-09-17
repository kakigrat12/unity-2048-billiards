using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    private void Awake()
    {
        // Make the game run as fast as possible in the web player
        Application.targetFrameRate = 300;
    }
}
