using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New StaffData", menuName = "ScriptableObjects/StaffData", order = 1)]
public class StaffData : ScriptableObject
{
    public PositonKeyDataPair[] positonKeyDataPairs;

    public PositonKeyDataPair GetStaffData(int index)
    {
        return positonKeyDataPairs[index];
    }

    public int GetRandomPairIndex()
    {
        return UnityEngine.Random.Range(0,positonKeyDataPairs.Length);
    }
}

[Serializable]
public struct PositonKeyDataPair
{
    public KeyData[] PossibleKeyData;

    public KeyData GetRandomKeyData()
    {
        return PossibleKeyData[UnityEngine.Random.Range(0, PossibleKeyData.Length)];
    }
}

//[Serializable]
//public struct StaffObject
//{
//    public KeyData Key;

//    public int[] PositionInStaff;
//    public Sprite MainSymbol;
//    public Sprite AccidentalSymbol;
//}
