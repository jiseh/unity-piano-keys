using System;
using System.Collections.Generic;
using UnityEngine;

public class GameModeSingleKey : MonoBehaviour
{
    [SerializeField] private GameInputManager _gameInputManager;
    [SerializeField] private StaffData _staffData;
    [SerializeField] private NoteSkeleton _noteSkeleton;
    [SerializeField] private Timer _timer;
    [SerializeField] private Transform[] _positions;

    private KeyData _queuedKeyData;

    private void Awake()
    {
        _gameInputManager.OnPianoButtonClicked.AddListener(OnPianoButtonClickedCallback);
    }

    private void OnDestroy()
    {
        _gameInputManager.OnPianoButtonClicked.RemoveListener(OnPianoButtonClickedCallback);
    }

    private void OnPianoButtonClickedCallback(KeyData[] keyDatas)
    {
        if (_queuedKeyData == null)
            return;
        foreach (KeyData keyData in keyDatas)
        {
            if (keyData == _queuedKeyData)
                Debug.Log($"Match! {keyData}");
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
            _timer.ToggleTimer(!_timer.TimerActive);
    }

    [ContextMenu("StartGame")]
    private void StartGame()
    {
        _timer.AddListenerToOnTimerEnd(OnTimerEndCallback);
        _timer.StartTimer(5f);
        ClearPositionAndPromptKey();
    }

    [ContextMenu("EndGame")]
    private void EndGame()
    {
        _timer.RemoveListenerToOnTimerEnd(OnTimerEndCallback);
        ClearPositionAndPromptKey();
    }

    private void OnTimerEndCallback()
    {
        _timer.StartTimer(5f);
        ClearPositionAndPromptKey();
    }

    private void ClearPositionAndPromptKey()
    {
        ClearPositions();
        PromptKeyInRandomPosition();
    }

    private void PromptKeyInRandomPosition()
    {
        int index = _staffData.GetRandomPairIndex();
        index = UnityEngine.Random.Range(0, 4);
        PositonKeyDataPair pair = _staffData.GetStaffData(index);
        KeyData keyData = pair.GetRandomKeyData();

        NoteSkeleton newNote = Instantiate(_noteSkeleton, _positions[index]);
        newNote.SetAccidental(keyData.Type);
        _queuedKeyData = keyData;
    }

    private void ClearPositions()
    {
        foreach (Transform item in _positions)
            DestroyAllChildOfTransform(item);
    }

    private void DestroyAllChildOfTransform(Transform transform)
    {
        if (transform.childCount <= 0)
            return;

        List<Transform> tempList = new();
        for (int i = 0; i < transform.childCount; i++)
            tempList.Add(transform.GetChild(i));
        foreach (Transform item in tempList)
            Destroy(item.gameObject);
    }
}