using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHUDPanel : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private Image _fill;

    private void Start()
    {
        _timer.AddListenerToOnTimerStart(TimerStartCallback);
        _timer.AddListenerToOnTimerUpdate(TimerUpdateCallback);
        _timer.AddListenerToOnTimerEnd(TimerEndCallback);   
    }

    private void OnDestroy()
    {
        _timer.RemoveListenerToOnTimerStart(TimerStartCallback);
        _timer.RemoveListenerToOnTimerUpdate(TimerUpdateCallback);
        _timer.RemoveListenerToOnTimerEnd(TimerEndCallback);
    }

    private void TimerStartCallback(float max)
    {
        _time.text = max.ToString();
        _fill.fillAmount = 1f;
    }

    private void TimerUpdateCallback(float current, float max)
    {
        _time.text = Mathf.Round(current).ToString();
        _fill.fillAmount = (current/max);
        ChangeFillColor(current/max);
    }

    private void TimerEndCallback()
    {
        _time.text = $"0";
        _fill.fillAmount = 0f;
    }

    private void ChangeFillColor(float ratio)
    {
        if (ratio > 0.66f)
            _fill.color = Color.green;
        else if(ratio > 0.33f) 
            _fill.color = Color.yellow;
        else 
            _fill.color = Color.red;
    }
}
