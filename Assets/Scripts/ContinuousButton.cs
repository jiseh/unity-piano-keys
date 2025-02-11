using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ContinuousButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [HideInInspector] public UnityEvent OnPointerDownEvent = new();

    private bool _pressed;

    private void Update()
    {
        if (_pressed)
            OnPointerDownEvent?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _pressed = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
    }
}
