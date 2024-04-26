using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpecialRewardCardController : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private Transform _specialRewardCard;
    [SerializeField] private TextMeshProUGUI _earnCardName;
    [SerializeField] private Button _collectRewardButtonReferences;

    private Button _collectRewardButton;
    private SliceData _sliceData;

    private void OnValidate()
    {
        _collectRewardButton = _collectRewardButtonReferences;
    }


    private void OnEnable()
    {
        _collectRewardButton.onClick.AddListener(CollectReward);
    }

    private void OnDisable()
    {
        _collectRewardButton.onClick.RemoveListener(CollectReward);
    }

    private void CollectReward()
    {
        EventManager<SliceData>.Execute(GameEvents.OnCollectSpecialReward, _sliceData);

        ResetLevel();
    }

    public void CheckSpecialRewardCard(LevelType levelType)
    {
        if (levelType == LevelType.Default)
        {
            SetAndActivateSpecialRewardCard(TypesOfSlice.BayonetEasterTime);
        }
    }

    public void SetAndActivateSpecialRewardCard(TypesOfSlice sliceType)
    {
        _specialRewardCard.gameObject.SetActive(true);
        _collectRewardButton.gameObject.SetActive(true);

        Sprite _iconSprite = UiImageSelect.GetSlicedItemSprite(sliceType);
        _iconImage.sprite = _iconSprite;
        _earnCardName.SetText(UiImageSelect.GetSlicedItemName(sliceType));

        ImageScaler.Instance.SetImageSize(_iconSprite, _iconImage.rectTransform);

        _sliceData = new SliceData();
        _sliceData.amount = 1;
        _sliceData.sliceType = sliceType;

    }

    public void ResetLevel()
    {
        _specialRewardCard.gameObject.SetActive(false);
        _collectRewardButton.gameObject.SetActive(false);
    }

}
