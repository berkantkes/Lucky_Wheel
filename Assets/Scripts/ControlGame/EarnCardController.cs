using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EarnCardController : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _amount;
    [SerializeField] private Transform _earnCard;
    [SerializeField] private TextMeshProUGUI _earnCardName;
    [SerializeField] private Button _giveUpButtonReferences;

    private Button _giveUpButton;

    private void OnValidate()
    {
        _giveUpButton = _giveUpButtonReferences;
    }

    private void OnEnable()
    {
        _giveUpButton.onClick.AddListener(GiveUp);
    }

    private void OnDisable()
    {
        _giveUpButton.onClick.RemoveListener(GiveUp);
    }

    private void GiveUp()
    {
        EventManager.Execute(GameEvents.OnGiveUp);

        ResetLevel();
    }

    public void SetAndActivateEarnCard(SliceData slicedData)
    {
        _earnCard.gameObject.SetActive(true);
        Sprite _iconSprite = UiImageSelect.GetSlicedItemSprite(slicedData.sliceType);
        _iconImage.sprite = _iconSprite;
        _amount.SetText("x" + slicedData.amount.ToString());
        _earnCardName.SetText(UiImageSelect.GetSlicedItemName(slicedData.sliceType));

        ImageScaler.Instance.SetImageSize(_iconSprite, _iconImage.rectTransform);

        DOVirtual.DelayedCall(2f, () => {
            _earnCard.gameObject.SetActive(false);
        });
    }

    public void DeathCard(SliceData slicedData)
    {
        _earnCard.gameObject.SetActive(true);
        Sprite _iconSprite = UiImageSelect.GetSlicedItemSprite(slicedData.sliceType);
        _iconImage.sprite = _iconSprite;
        _amount.SetText("");
        _earnCardName.SetText("");
        ImageScaler.Instance.SetImageSize(_iconSprite, _iconImage.rectTransform);
        _giveUpButton.gameObject.SetActive(true);
    }

    public void ResetLevel()
    {
        _earnCard.gameObject.SetActive(false);
        _giveUpButton.gameObject.SetActive(false);
    }
}
