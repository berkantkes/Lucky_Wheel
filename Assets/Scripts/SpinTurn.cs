using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinTurn : MonoBehaviour
{
    [SerializeField] private Transform _uiSpin;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Button _spinButton;
    [SerializeField] private SpinSlicedManager _spinSlicedManager;
    [SerializeField] private RewardCollecterManager _rewardCollecterManager;

    private LuckyWheelData _luckyWheelData;
    private LevelManager _levelManager;
    private int selectItemIndex;

    private void OnEnable()
    {
        _spinButton.onClick.AddListener(Spin);
    }
    private void OnDisable()
    {
        _spinButton.onClick.RemoveListener(Spin);
    }

    public void Instant(LuckyWheelData luckyWheelData, LevelManager levelManager)
    {
        _luckyWheelData = luckyWheelData;
        _levelManager = levelManager;
        LoadLevel(luckyWheelData);
    }

    public void LoadLevel(LuckyWheelData luckyWheelData)
    {
        _luckyWheelData = luckyWheelData;
        _spinSlicedManager.SetSlicedsData(_luckyWheelData);
        _uiSpin.transform.localRotation = Quaternion.identity;
    }

    public void Spin()
    {
        SetSpinEnable(false);
        selectItemIndex = Random.Range(0, 8);

        _uiSpin.DORotate(new Vector3(0, 0, ((3 * 360) + selectItemIndex * 45)), 3, RotateMode.FastBeyond360)
            .SetEase(curve)
            .OnComplete(() =>
            {
                _rewardCollecterManager.AddReward(_luckyWheelData.luckyWheelDatas[selectItemIndex]);
                _levelManager.LevelUp();
            });
    }

    private void SetSpinEnable(bool status)
    {
        _spinButton.enabled = status;
    }
}
