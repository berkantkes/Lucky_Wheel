using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelBarManager : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _levelTexts;
    [SerializeField] private Transform _levelTextsParentTransform;
    [SerializeField] private Image _levelBgImage;
    [SerializeField] private Sprite _levelTextBgDefault;
    [SerializeField] private Sprite _levelTextBg5;
    [SerializeField] private Sprite _levelTextBg30;

    private LevelManager _levelManager;
    private int _xSpacing = 240;
    private float _levelTextMoveDuration = 1;

    public void Initialize(LevelManager levelManager)
    {
        _levelManager = levelManager;

        for (int i = 0; i < _levelTexts.Count; i++)
        {
            _levelTexts[i].SetText((i + 1).ToString());
            _levelTexts[i].transform.localPosition = new Vector3(i * _xSpacing, 0, 0);
            _levelBgImage.sprite = _levelTextBgDefault;

            LevelType levelType = _levelManager.GetLevelType(i + 1);

            if (levelType == LevelType.SuperZone)
            {
                _levelBgImage.sprite = _levelTextBg30;
                _levelTexts[i].color = Color.green;
                continue;
            }
            else if (levelType == LevelType.SafeZone)
            {
                _levelBgImage.sprite = _levelTextBg5;
                _levelTexts[i].color = Color.blue;
            }
            else
            {
                _levelBgImage.sprite = _levelTextBgDefault;
            }
        }
    }

    private void OnEnable()
    {
        EventManager.Subscribe(GameEvents.OnGiveUp, ResetLevel);
        EventManager.Subscribe(GameEvents.OnLevelEnd, ResetLevel);
        EventManager.Subscribe(GameEvents.OnCollectRewards, ResetLevel);
    }

    private void OnDisable()
    {
        EventManager.Unsubscribe(GameEvents.OnGiveUp, ResetLevel);
        EventManager.Unsubscribe(GameEvents.OnLevelEnd, ResetLevel);
        EventManager.Unsubscribe(GameEvents.OnCollectRewards, ResetLevel);
    }


    public void LevelUp(LevelType levelType)
    {
        _levelTextsParentTransform.DOLocalMoveX(_levelTextsParentTransform.localPosition.x - _xSpacing, _levelTextMoveDuration)
            .SetEase(Ease.InOutCubic);

        if (levelType == LevelType.SuperZone)
        {
            _levelBgImage.sprite = _levelTextBg30;
        }
        else if (levelType == LevelType.SafeZone)
        {
            _levelBgImage.sprite = _levelTextBg5;
        }
        else
        {
            _levelBgImage.sprite = _levelTextBgDefault;
        }
    }

    public void ResetLevel()
    {
        _levelTextsParentTransform.transform.localPosition = Vector3.zero;
        _levelBgImage.sprite = _levelTextBgDefault;
    }

}
