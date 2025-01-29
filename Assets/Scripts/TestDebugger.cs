using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDebugger : MonoBehaviour
{
    [SerializeField] private RectTransform _bg;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private float _value; 

    void Update()
    {
        Vector3[] v = new Vector3[4];
        _rectTransform.GetWorldCorners(v);
        float _fullPianoHalfWidth = _rectTransform.rect.width / 2;
        float _pianoViewportHalfWidth = _bg.rect.width / 2;
        float final =  _fullPianoHalfWidth - _pianoViewportHalfWidth;
        _rectTransform.anchoredPosition = new Vector2(Mathf.Clamp(_value, -final, final), _rectTransform.anchoredPosition.y);
    }
}
