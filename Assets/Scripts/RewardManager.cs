using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _amountText;

    private int _amountCount = 0;

    public void SetSliceDatas(SlicedData slicedData)
    {
        _amountCount += slicedData.amount;
        _amountText.SetText("x" + _amountCount);

        GameObject itemImage = Instantiate(UiImageSelect.GetSlicedItemImage(slicedData.slicedType), transform);

        itemImage.transform.localPosition = Vector3.zero;
    }
}
