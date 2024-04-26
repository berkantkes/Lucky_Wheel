using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiImageSelect : MonoBehaviour
{
    [SerializeField] private IconImageController _cashGameobject;
    [SerializeField] private IconImageController _goldGameobject;
    [SerializeField] private IconImageController _chestGameobject;
    [SerializeField] private IconImageController _itemPointsGameobject;
    [SerializeField] private IconImageController _deathGameobject;
    [SerializeField] private IconImageController _weaponGameobject;
    [SerializeField] private IconImageController _supportiveGameobject;
    [SerializeField] private IconImageType _iconImageType;

    private static Dictionary<TypesOfSlice, IconImageController> _slicedGameobject;
    private static Dictionary<TypesOfSlice, GeneralTypesOfSlice> _generalTypes;
    private static Dictionary<TypesOfSlice, (Sprite, string)> _itemImages = new Dictionary<TypesOfSlice, (Sprite, string)>();

    public void Initialize()
    {
        foreach (var iconData in _iconImageType.iconImageDatas)
        {
            _itemImages.Add(iconData.slicedType, (iconData._iconSprite, iconData._name));
        }

        _slicedGameobject = GetSlicedGameobject();
        _generalTypes = GetSlicedGeneralTypes();
    }

    private Dictionary<TypesOfSlice, IconImageController> GetSlicedGameobject()
    {
        Dictionary<TypesOfSlice, IconImageController> slicedItemImages = new Dictionary<TypesOfSlice, IconImageController>
        {
            [TypesOfSlice.Cash] = _cashGameobject,
            [TypesOfSlice.Gold] = _goldGameobject,
            [TypesOfSlice.ChestBig] = _chestGameobject,
            [TypesOfSlice.ChestBronze] = _chestGameobject,
            [TypesOfSlice.ChestGold] = _chestGameobject,
            [TypesOfSlice.ChestSilver] = _chestGameobject,
            [TypesOfSlice.ChestSmall] = _chestGameobject,
            [TypesOfSlice.ChestStandart] = _chestGameobject,
            [TypesOfSlice.ChestSuper] = _chestGameobject,
            [TypesOfSlice.GrenadeM26] = _supportiveGameobject,
            [TypesOfSlice.GrenadeM67] = _supportiveGameobject,
            [TypesOfSlice.Neurostim] = _supportiveGameobject,
            [TypesOfSlice.Regenerator] = _supportiveGameobject,
            [TypesOfSlice.Molotov] = _supportiveGameobject,
            [TypesOfSlice.ShotgunTier1] = _weaponGameobject,
            [TypesOfSlice.MleTier2] = _weaponGameobject,
            [TypesOfSlice.RifleTier2] = _weaponGameobject,
            [TypesOfSlice.ShotgunTier3] = _weaponGameobject,
            [TypesOfSlice.SmgTier3] = _weaponGameobject,
            [TypesOfSlice.SniperTier3] = _weaponGameobject,
            [TypesOfSlice.ArmorPoints] = _itemPointsGameobject,
            [TypesOfSlice.KnifePoints] = _itemPointsGameobject,
            [TypesOfSlice.PistolPoints] = _itemPointsGameobject,
            [TypesOfSlice.RifflePoints] = _itemPointsGameobject,
            [TypesOfSlice.ShotgunPoints] = _itemPointsGameobject,
            [TypesOfSlice.SMGPoints] = _itemPointsGameobject,
            [TypesOfSlice.SniperPoints] = _itemPointsGameobject,
            [TypesOfSlice.SubmachinePoints] = _itemPointsGameobject,
            [TypesOfSlice.Death] = _deathGameobject,
            [TypesOfSlice.BayonetEasterTime] = _weaponGameobject,
            [TypesOfSlice.BayonetSummerVice] = _weaponGameobject,

        };

        return slicedItemImages;
    }
    private Dictionary<TypesOfSlice, GeneralTypesOfSlice> GetSlicedGeneralTypes()
    {
        Dictionary<TypesOfSlice, GeneralTypesOfSlice> slicedItemImages = new Dictionary<TypesOfSlice, GeneralTypesOfSlice>
        {
            [TypesOfSlice.Cash] = GeneralTypesOfSlice.Cash,
            [TypesOfSlice.Gold] = GeneralTypesOfSlice.Gold,
            [TypesOfSlice.ChestBig] = GeneralTypesOfSlice.Chest,
            [TypesOfSlice.ChestBronze] = GeneralTypesOfSlice.Chest,
            [TypesOfSlice.ChestGold] = GeneralTypesOfSlice.Chest,
            [TypesOfSlice.ChestSilver] = GeneralTypesOfSlice.Chest,
            [TypesOfSlice.ChestSmall] = GeneralTypesOfSlice.Chest,
            [TypesOfSlice.ChestStandart] = GeneralTypesOfSlice.Chest,
            [TypesOfSlice.ChestSuper] = GeneralTypesOfSlice.Chest,
            [TypesOfSlice.GrenadeM26] = GeneralTypesOfSlice.Supportive,
            [TypesOfSlice.GrenadeM67] = GeneralTypesOfSlice.Supportive,
            [TypesOfSlice.Neurostim] = GeneralTypesOfSlice.Supportive,
            [TypesOfSlice.Regenerator] = GeneralTypesOfSlice.Supportive,
            [TypesOfSlice.Molotov] = GeneralTypesOfSlice.Supportive,
            [TypesOfSlice.ShotgunTier1] = GeneralTypesOfSlice.Weapon,
            [TypesOfSlice.MleTier2] = GeneralTypesOfSlice.Weapon,
            [TypesOfSlice.RifleTier2] = GeneralTypesOfSlice.Weapon,
            [TypesOfSlice.ShotgunTier3] = GeneralTypesOfSlice.Weapon,
            [TypesOfSlice.SmgTier3] = GeneralTypesOfSlice.Weapon,
            [TypesOfSlice.SniperTier3] = GeneralTypesOfSlice.Weapon,
            [TypesOfSlice.ArmorPoints] = GeneralTypesOfSlice.ItemPoints,
            [TypesOfSlice.KnifePoints] = GeneralTypesOfSlice.ItemPoints,
            [TypesOfSlice.PistolPoints] = GeneralTypesOfSlice.ItemPoints,
            [TypesOfSlice.RifflePoints] = GeneralTypesOfSlice.ItemPoints,
            [TypesOfSlice.ShotgunPoints] = GeneralTypesOfSlice.ItemPoints,
            [TypesOfSlice.SMGPoints] = GeneralTypesOfSlice.ItemPoints,
            [TypesOfSlice.SniperPoints] = GeneralTypesOfSlice.ItemPoints,
            [TypesOfSlice.SubmachinePoints] = GeneralTypesOfSlice.ItemPoints,
            [TypesOfSlice.Death] = GeneralTypesOfSlice.Death,
            [TypesOfSlice.BayonetEasterTime] = GeneralTypesOfSlice.Weapon,
            [TypesOfSlice.BayonetSummerVice] = GeneralTypesOfSlice.Weapon,

        };

        return slicedItemImages;
    }

    public static IconImageController GetSlicedItemGameObject(TypesOfSlice slicedTypes)
    {
        return _slicedGameobject[slicedTypes];
    }

    public static Sprite GetSlicedItemSprite(TypesOfSlice slicedTypes)
    {
        return _itemImages[slicedTypes].Item1;
    }
    public static string GetSlicedItemName(TypesOfSlice slicedTypes)
    {
        return _itemImages[slicedTypes].Item2;
    }

    public static GeneralTypesOfSlice GetSlicedGeneralTypes(TypesOfSlice slicedTypes)
    {
        return _generalTypes[slicedTypes];
    }


}
