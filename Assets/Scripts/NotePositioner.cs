using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePositioner : MonoBehaviour
{
    [SerializeField] private Transform _origin;
    [SerializeField] private float _offset;
    [SerializeField] private int _count;

    [ContextMenu("Build Transform")]
    public void BuildTransform()
    {
        float offset = 0;
        for (int i = 0; i < _count; i++)
        {
            GameObject newGO = new GameObject();
            newGO.transform.position = _origin.position + new Vector3(0, offset, 0);
            newGO.transform.SetParent(_origin);
            offset += _offset;
        }
    }
}
