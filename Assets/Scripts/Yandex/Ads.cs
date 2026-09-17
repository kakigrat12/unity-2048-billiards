using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Ads : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();

    [DllImport("__Internal")]
    private static extern void ShowRewardedAdv();

    [SerializeField] private bool _onAwake;

    public event Action Rewarded;
    public event Action RewardCancled;

    private void Start()
    {
        if (_onAwake)
            ShowAds();
    }

    public void ShowAds()
    {
        if (!gameObject.activeSelf)
        {
            return;
        }

        ShowAdv();

        Debug.Log("Opened");
        //Invoke(nameof(AdsClosed), 2f);
    }

    public void AdsClosed()
    {
        Debug.Log("Closed");
    }

    public void ShowRewardedAds()
    {
        if (!gameObject.activeSelf)
        {
            return;
        }

        ShowRewardedAdv();
    }

    public void AdsRewardedClosed()
    {
        RewardCancled?.Invoke();
    }

    public void AdsRewarded()
    {
        Rewarded?.Invoke();
    }
}
