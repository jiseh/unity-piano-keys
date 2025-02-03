using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New StaffData", menuName = "ScriptableObjects/StaffData", order = 1)]
public class StaffData : ScriptableObject
{
    public PositonKeyDataPair[] positonKeyDataPairs;
}

[Serializable]
public struct PositonKeyDataPair
{
    public int PositionInStaff;
    public KeyData[] PossibleKeyData;
}

//[Serializable]
//public struct StaffObject
//{
//    public KeyData Key;

//    public int[] PositionInStaff;
//    public Sprite MainSymbol;
//    public Sprite AccidentalSymbol;
//}
