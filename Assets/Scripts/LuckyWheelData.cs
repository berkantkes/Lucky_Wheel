using System;
using System.Collections.Generic;
using UnityEngine;

public enum SlicedTypes
{
    Cash,
    Gold,
    ChestBig,
    ArmorPoints,
    Death

}


[Serializable]
public class SlicedData
{
    public int amount;
    public SlicedTypes slicedType;
}


[Serializable]
[CreateAssetMenu(fileName = "LuckyWheelData", menuName = "ScriptableObjects/MyData")]
public class LuckyWheelData : ScriptableObject
{
    public List<SlicedData> luckyWheelDatas = new List<SlicedData>();
}
