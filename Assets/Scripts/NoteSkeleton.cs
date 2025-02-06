using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSkeleton : MonoBehaviour
{
    //[SerializeField] private SpriteRenderer _spriteRenderer;

    [Header("Accidental")]
    [SerializeField] private GameObject _flat;
    [SerializeField] private GameObject _sharp;
    [SerializeField] private Transform _accidental;

    public void SetAccidental(NoteType noteType)
    {
        DestroyAllChildOfTransform(_accidental);
        switch (noteType)
        {
            case NoteType.Standard:
                break;
            case NoteType.Flat:
                Instantiate(_flat, _accidental);
                break;
            case NoteType.Sharp:
                Instantiate(_sharp, _accidental);
                break;
            default:
                break;
        }
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
