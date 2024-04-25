using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ImageData
{
    public Sprite _iconSprite;
    public TypesOfSlice slicedType;
    public string _name;
}

[Serializable]
[CreateAssetMenu(fileName = "IconImageType", menuName = "ScriptableObjects/IconImageData")]
public class IconImageType : ScriptableObject
{
    public List<ImageData> iconImageDatas = new List<ImageData>();
}
