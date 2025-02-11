using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDebugger : MonoBehaviour
{
    [SerializeField] private GameInputManager _gameInputManager;
    [SerializeField] private RectTransform _bg;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private float _value;
    [SerializeField] private float _scrollSpeed;

    private void Awake()
    {
        _gameInputManager.OnScrollLeft.AddListener(OnScrollleftCallback);
        _gameInputManager.OnScrollRight.AddListener(OnScrollRightCallback);
    }

    private void OnScrollleftCallback()
    {
        float _fullPianoHalfWidth = _rectTransform.rect.width / 2;
        float _pianoViewportHalfWidth = _bg.rect.width / 2;
        float final = _fullPianoHalfWidth - _pianoViewportHalfWidth;
        _value = Mathf.Clamp(_value + Time.deltaTime * _scrollSpeed, -final, final);
    }

    private void OnScrollRightCallback()
    {
        float _fullPianoHalfWidth = _rectTransform.rect.width / 2;
        float _pianoViewportHalfWidth = _bg.rect.width / 2;
        float final = _fullPianoHalfWidth - _pianoViewportHalfWidth;
        _value = Mathf.Clamp(_value - Time.deltaTime * _scrollSpeed, -final, final);
    }

    private void Start()
    {
        float _fullPianoHalfWidth = _rectTransform.rect.width / 2;
        float _pianoViewportHalfWidth = _bg.rect.width / 2;
        float final = _fullPianoHalfWidth - _pianoViewportHalfWidth;
        Debug.Log($"{final}");
    }

    void Update()
    {
        //Vector3[] v = new Vector3[4];
        //_rectTransform.GetWorldCorners(v);
        float _fullPianoHalfWidth = _rectTransform.rect.width / 2;
        float _pianoViewportHalfWidth = _bg.rect.width / 2;
        float final =  _fullPianoHalfWidth - _pianoViewportHalfWidth;
        _rectTransform.anchoredPosition = new Vector2(_value, _rectTransform.anchoredPosition.y);
    }
}
