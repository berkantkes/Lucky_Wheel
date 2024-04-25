using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _amount;

    IconImageController _iconImageController;
    private GameObject _imageObject;

    private int _currentAmount = 0;

    public void SetSliceDatas(SliceData sliceData)
    {
        if (_iconImageController != null)
        {
            Destroy(_iconImageController.gameObject);
        }

        _currentAmount += sliceData.amount;
        _amount.SetText("x" + _currentAmount);

        _iconImageController = Instantiate(UiImageSelect.GetSlicedItemGameObject(sliceData.sliceType), transform);

        _iconImageController.SetSprite(UiImageSelect.GetSlicedItemSprite(sliceData.sliceType));

        _iconImageController.transform.localPosition = Vector3.zero;

        _imageObject = _iconImageController.gameObject;
    }

    public void ResetRewardItem()
    {
        _currentAmount = 0;
        _amount.SetText("");
        Destroy(_imageObject);
    }

}
