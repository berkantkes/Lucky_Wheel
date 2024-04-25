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
    [SerializeField] private IconImageController _weapenGameobject;
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
            [TypesOfSlice.ArmorPoints] = _itemPointsGameobject,
            [TypesOfSlice.KnifePoints] = _itemPointsGameobject,
            [TypesOfSlice.PistolPoints] = _itemPointsGameobject,
            [TypesOfSlice.RifflePoints] = _itemPointsGameobject,
            [TypesOfSlice.ShotgunPoints] = _itemPointsGameobject,
            [TypesOfSlice.Death] = _deathGameobject,

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
            [TypesOfSlice.ArmorPoints] = GeneralTypesOfSlice.ItemPoints,
            [TypesOfSlice.KnifePoints] = GeneralTypesOfSlice.ItemPoints,
            [TypesOfSlice.PistolPoints] = GeneralTypesOfSlice.ItemPoints,
            [TypesOfSlice.RifflePoints] = GeneralTypesOfSlice.ItemPoints,
            [TypesOfSlice.ShotgunPoints] = GeneralTypesOfSlice.ItemPoints,
            [TypesOfSlice.Death] = GeneralTypesOfSlice.Death,

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
