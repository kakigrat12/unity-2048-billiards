using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    public void SetValume(float value)
    {
        _audioMixerGroup.audioMixer.SetFloat("Volume", value);
    }
}
