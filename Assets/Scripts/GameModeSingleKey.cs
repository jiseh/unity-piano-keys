using System;
using System.Collections.Generic;
using UnityEngine;

public class GameModeSingleKey : MonoBehaviour
{
    [SerializeField] private StaffData _staffData;
    [SerializeField] private NoteSkeleton _noteSkeleton;
    [SerializeField] private Timer _timer;
    [SerializeField] private Transform[] _positions;

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
        PositonKeyDataPair pair = _staffData.GetStaffData(index);
        KeyData keyData = pair.GetRandomKeyData();

        NoteSkeleton newNote = Instantiate(_noteSkeleton, _positions[index]);
        newNote.SetAccidental(keyData.Type);
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