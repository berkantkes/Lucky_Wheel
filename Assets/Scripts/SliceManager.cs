using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliceManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _amount;

    public void SetSliceDatas(SlicedData slicedData)
    {
        _amount.SetText("x" + slicedData.amount);

        GameObject itemImage = Instantiate(UiImageSelect.GetSlicedItemImage(slicedData.slicedType), transform);
    }
}
