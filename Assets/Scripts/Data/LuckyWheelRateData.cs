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
    ChestStandart,
    ChestSuper,
    GrenadeM26,
    GrenadeM67,
    Neurostim,
    Regenerator,
    Molotov,
    ShotgunTier1,
    MleTier2,
    RifleTier2,
    ShotgunTier3,
    SmgTier3,
    SniperTier3,
    ArmorPoints,
    KnifePoints,
    PistolPoints,
    RifflePoints,
    ShotgunPoints,
    SMGPoints,
    SniperPoints,
    SubmachinePoints,
    Death,
    BayonetEasterTime,
    BayonetSummerVice,

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

