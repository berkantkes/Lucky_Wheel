using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiImageSelect : MonoBehaviour
{
    [SerializeField] private GameObject _cashImage;
    [SerializeField] private GameObject _goldImage;
    [SerializeField] private GameObject _chestBigImage;
    [SerializeField] private GameObject _armorPointsImage;

    private static Dictionary<SlicedTypes, GameObject> slicedItemImages = new Dictionary<SlicedTypes, GameObject>();

    public void CreateDictionary()
    {
        slicedItemImages.Add(SlicedTypes.Cash, _cashImage);
        slicedItemImages.Add(SlicedTypes.Gold, _goldImage);
        slicedItemImages.Add(SlicedTypes.ChestBig, _chestBigImage);
        slicedItemImages.Add(SlicedTypes.ArmorPoints, _armorPointsImage);
    }

    public static GameObject GetSlicedItemImage(SlicedTypes slicedTypes)
    {
        return slicedItemImages[slicedTypes];
    }


}
