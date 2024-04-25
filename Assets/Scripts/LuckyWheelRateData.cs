using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SlicedRateData
{
    public float rate;
    public TypesOfSlice sliceType;
}

[Serializable]
[CreateAssetMenu(fileName = "LuckyWheelData", menuName = "ScriptableObjects/MyData")]
public class LuckyWheelRateData : ScriptableObject
{
    public List<SlicedRateData> SlicesRateData = new List<SlicedRateData>();
}

public enum TypesOfSlice
{
    Cash,
    Gold,
    ChestBig,
    ChestBronze,
    ChestGold,
    ChestSilver,
    ChestSmall,
    ArmorPoints,
    KnifePoints,
    PistolPoints,
    RifflePoints,
    ShotgunPoints,
    Death

}
public enum GeneralTypesOfSlice
{
    ItemPoints,
    Chest,
    Cash,
    Gold,
    Weapon,
    Supportive,
    Death
}

