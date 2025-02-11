using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameInputManager : MonoBehaviour
{
    [HideInInspector] public UnityEvent<KeyData[]> OnPianoButtonClicked = new();
    [HideInInspector] public UnityEvent OnScrollLeft = new();
    [HideInInspector] public UnityEvent OnScrollRight = new();

    [SerializeField] private List<PianoButton> _buttons;
    [SerializeField] private Button _toggleLabel;
    [SerializeField] private ContinuousButton _scrollLeft;
    [SerializeField] private ContinuousButton _scrollRigt;
    [SerializeField] private Button _pause;

    private void Start()
    {
        foreach (PianoButton button in _buttons)
            button.OnButtonPress.AddListener(OnPianoButtonPressCallback);

        _scrollLeft.OnPointerDownEvent.AddListener(OnScrollLeftClick);
        _scrollRigt.OnPointerDownEvent.AddListener(OnScrollRightClick);
    }

    private void OnDestroy()
    {
        foreach (PianoButton button in _buttons)
            button.OnButtonPress.RemoveListener(OnPianoButtonPressCallback);
    }

    private void OnPianoButtonPressCallback(KeyData[] keyDatas)
    {
        //foreach (KeyData keyData in keyDatas)
        //    Debug.Log(keyData);
        OnPianoButtonClicked?.Invoke(keyDatas);
    }

    private void OnScrollLeftClick()
    {
        OnScrollLeft?.Invoke();
    }

    private void OnScrollRightClick()
    {
        OnScrollRight?.Invoke();
    }
}
