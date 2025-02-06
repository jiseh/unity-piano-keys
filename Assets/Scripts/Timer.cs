using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public bool TimerActive { get { return _timerActive; } }

    [Header("Debugging")]
    [SerializeField] private bool _timeLogging;

    private UnityEvent OnTimerEnd = new();
    private float _currentTime;
    private bool _timerActive;

    private void Update()
    {
        HandleTimer();
    }

    public void StartTimer(float duration, bool overrideTimerInProgress = false)
    {
        if (_timerActive)
        {
            Debug.LogWarning($"Timer is active with {_currentTime} left");
            if (!overrideTimerInProgress)
            {
                Debug.LogWarning($"StartTimer aborted, parameters was not set to override timer in progress");
                return;
            }
        } 
        _currentTime = duration;
        _timerActive = true;
    }

    public void ToggleTimer(bool value)
    {
        _timerActive = value;
    }

    public void PlayTimer()
    {
        _timerActive = true;
    }

    public void PauseTimer()
    {
        _timerActive = false;
    }

    public void AddListenerToOnTimerEnd(UnityAction unityAction)
    {
        OnTimerEnd.AddListener(unityAction);
    }

    public void RemoveListenerToOnTimerEnd(UnityAction unityAction)
    {
        OnTimerEnd.RemoveListener(unityAction);
    }

    private void HandleTimer()  
    {
        if (!_timerActive)
            return;
        _currentTime -= Time.deltaTime;
        TryLoggingCurrentTime();
        if (_currentTime <= 0)
        {
            _timerActive = false;
            OnTimerEnd?.Invoke();
        }
    }

    private void TryLoggingCurrentTime()
    {
        if(_timeLogging)
            Debug.Log($"CurrentTime: {_currentTime}");
    }

    #region Debugger
    [ContextMenu("StartTimerFiveSeconds")]
    private void StartTimerFiveSeconds()
    {
        StartTimer(5f, false);
    }

    [ContextMenu("StartTimerFiveSecondsOverride")]
    private void StartTimerTenSecondsOverride()
    {
        StartTimer(10f, true);
    }
    #endregion
}
