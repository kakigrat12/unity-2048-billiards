using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    [SerializeField] private VideoPlayer _player;
    [SerializeField] private string _videoFileName;

    private void OnEnable()
    {
        Play();
    }

    private void Play()
    {
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, _videoFileName);
        _player.url = videoPath;
        _player.Play();
    }
}
