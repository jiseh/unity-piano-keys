using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New KeyData", menuName = "ScriptableObjects/KeyData", order = 1)]
public class KeyData : ScriptableObject
{
    public int Octave;
    public Note Note;
    public NoteType Type;
}

public enum Note
{
    C,
    D,
    E,
    F,
    G,
    A,
    B,
}

public enum NoteType
{
    Standard,
    Flat,
    Sharp,
}