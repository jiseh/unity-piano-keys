using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public bool TimerActive { get { return _timerActive; } }

    [Header("Debugging")]
    [SerializeField] private bool _timeLogging;

    private UnityEvent<float> OnTimerStart = new();
    private UnityEvent<float, float> OnTimerUpdate = new();
    private UnityEvent OnTimerEnd = new();
    private float _currentTime;
    private float _maxTime;
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
        _maxTime = duration;    
        _timerActive = true;
        OnTimerStart?.Invoke(duration);
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

    public void AddListenerToOnTimerStart(UnityAction<float> unityAction)
    {
        OnTimerStart.AddListener(unityAction);
    }

    public void RemoveListenerToOnTimerStart(UnityAction<float> unityAction)
    {
        OnTimerStart.RemoveListener(unityAction);
    }

    public void AddListenerToOnTimerUpdate(UnityAction<float, float> unityAction)
    {
        OnTimerUpdate.AddListener(unityAction);
    }

    public void RemoveListenerToOnTimerUpdate(UnityAction<float, float> unityAction)
    {
        OnTimerUpdate.RemoveListener(unityAction);
    }

    public void AddListenerToOnTimerEnd(UnityAction unityAction)
    {
        OnTimerEnd.AddListener(unityAction);
    }

    public void RemoveListenerToOnTimerEnd(UnityAction unityAction)
    {
        OnTimerEnd.RemoveListener(unityAction);
    }

    public float GetCurrentTimePrecise()
    {
        return _currentTime;
    }

    public float GetCurrentTimeRounded()
    {
        return Mathf.Round(_currentTime);
    }

    private void HandleTimer()  
    {
        if (!_timerActive)
            return;
        _currentTime -= Time.deltaTime;
        OnTimerUpdate?.Invoke(_currentTime, _maxTime);
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
