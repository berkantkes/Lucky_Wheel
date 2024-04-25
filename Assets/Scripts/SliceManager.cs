using TMPro;
using UnityEngine;

public class SliceManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _amount;

    IconImageController _iconImageController;

    public void SetSliceDatas(SliceData sliceData)
    {
        if (_iconImageController != null)
        {
            Destroy(_iconImageController.gameObject);
        }

        if (sliceData.amount != 0)
        {
            _amount.SetText("x" + sliceData.amount);
        }
        else
        {
            _amount.SetText("");
        }

        _iconImageController = Instantiate(UiImageSelect.GetSlicedItemGameObject(sliceData.sliceType), transform);

        _iconImageController.SetSprite(UiImageSelect.GetSlicedItemSprite(sliceData.sliceType));
    }
}
