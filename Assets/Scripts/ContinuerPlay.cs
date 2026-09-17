using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContinuerPlay : MonoBehaviour
{
    [SerializeField] private uint _removeBallsCount = 2;
    [SerializeField] private Ads _asd;
    [SerializeField] private Counter _counter;
    [SerializeField] private SmallestBallRemover _remover;
    [SerializeField] public GameRestarter _restarter;
    [SerializeField] private float _timeToWait = 3.6f;
    private Coroutine _currentWait;

    public UnityEvent Rewarded;
    public UnityEvent RewardCancled;

    private void OnEnable()
    {
        _currentWait = StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_timeToWait);
        OnRewardCancled();
    }

    public void ContinueWithAds()
    {
        _asd.ShowRewardedAds();
        _asd.Rewarded += OnRewarded;
        _asd.RewardCancled += OnRewardCancled;

        StopCoroutine(_currentWait);
    }

    private void Unsubscrib()
    {
        _asd.Rewarded -= OnRewarded;
        _asd.RewardCancled -= OnRewardCancled;
    }

    private void OnRewarded()
    {
        _remover.Remove((int)_removeBallsCount);
        _counter.TryToRemoveBalls(_removeBallsCount);
        Unsubscrib();
        Rewarded?.Invoke();
    }

    private void OnRewardCancled()
    {
        _restarter.Restart();
        Unsubscrib();
        RewardCancled?.Invoke();
    }
}
