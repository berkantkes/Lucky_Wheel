using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinBaseController : MonoBehaviour
{
    [SerializeField] Image _spinBase;
    [SerializeField] Image _spinIndicator;

    [SerializeField] Sprite _spinBaseBronze;
    [SerializeField] Sprite _spinBaseSilver;
    [SerializeField] Sprite _spinBaseGold;
    [SerializeField] Sprite _spinIndicatorBronze;
    [SerializeField] Sprite _spinIndicatorSilver;
    [SerializeField] Sprite _spinIndicatorGold;

    public void SetSpinBaseImage(LevelType levelType)
    {
        if (levelType == LevelType.SuperZone)
        {
            _spinBase.sprite = _spinBaseGold;
            _spinIndicator.sprite = _spinIndicatorGold;
        }
        else if (levelType == LevelType.SafeZone)
        {
            _spinBase.sprite = _spinBaseSilver;
            _spinIndicator.sprite = _spinIndicatorSilver;
        }
        else
        {
            _spinBase.sprite = _spinBaseBronze;
            _spinIndicator.sprite = _spinIndicatorBronze;
        }
    }
}
