using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PianoButton : MonoBehaviour
{
    [HideInInspector] public UnityEvent<KeyData[]> OnButtonPress = new();

    [SerializeField] private KeyData[] _possibleKeys;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();   
    }

    private void Start()
    {
        _button.onClick.AddListener(() => OnButtonPress.Invoke(_possibleKeys));
    }
}
