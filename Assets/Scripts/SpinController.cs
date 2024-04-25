using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinController : MonoBehaviour
{
    [SerializeField] private Transform _spinBase;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Button _spinButtonReferences;
    [SerializeField] private SpinSlicedManager _spinSlicedManager;
    [SerializeField] private RewardCollecterManager _rewardCollecterManager;

    private LevelManager _levelManager;
    private List<SliceData> _sliceData;
    private int selectItemIndex;
    private Button _spinButton;

    private void OnValidate()
    {
        _spinButton = _spinButtonReferences;
    }

    private void OnEnable()
    {
        _spinButton.onClick.AddListener(Spin);
        EventManager.Subscribe(GameEvents.OnGiveUp, GiveUp);
        EventManager.Subscribe(GameEvents.OnCollectRewards, GiveUp);
    }

    private void OnDisable()
    {
        _spinButton.onClick.RemoveListener(Spin);
        EventManager.Unsubscribe(GameEvents.OnGiveUp, GiveUp);
        EventManager.Unsubscribe(GameEvents.OnCollectRewards, GiveUp);
    }


    public void Initialize(LevelManager levelManager)
    {
        _levelManager = levelManager;
    }

    public void Spin()
    {
        SetSpinButtonEnable(false);
        selectItemIndex = Random.Range(0, 8);

        EventManager.Execute(GameEvents.OnStartSpinTurn);

        _spinBase.DORotate(new Vector3(0, 0, ((3 * 360) + selectItemIndex * 45)), 3, RotateMode.FastBeyond360)
            .SetEase(curve)
            .OnComplete(() =>
            {
                EndSpin();
            });
    }

    private void EndSpin()
    {
        SliceData slicedData = _sliceData[selectItemIndex];

        if (slicedData.sliceType != TypesOfSlice.Death)
        {
            EventManager<SliceData>.Execute(GameEvents.OnEarnReward, slicedData);

            _levelManager.LevelUp(slicedData);

            EventManager.Execute(GameEvents.OnEndSpinTurn);
        }
        else
        {
            _levelManager.DeathCard(slicedData);
        }
    }

    private void GiveUp()
    {
        SetSpinButtonEnable(true);
        ResetSpinBase();
    }

    public void SetSpinButtonEnable(bool status)
    {
        _spinButton.enabled = status;
    }

    public void ResetSpinBase()
    {
        _spinBase.transform.localRotation = Quaternion.identity;
    }
    public void SetSliceData(List<SliceData> sliceData)
    {
        _sliceData = sliceData;
    }
}
