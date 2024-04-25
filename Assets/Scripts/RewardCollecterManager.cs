using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardCollecterManager : MonoBehaviour
{
    [SerializeField] private List<RewardManager> _rewardManagersRewardPanel = new List<RewardManager>();
    [SerializeField] private List<RewardManager> _rewardManagersExitPanel = new List<RewardManager>();
    [SerializeField] private RectTransform _container;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _exitPanel;

    private Dictionary<TypesOfSlice, int> _rewards = new Dictionary<TypesOfSlice, int>();
    private LevelManager _levelManager;

    private int _rewardIndex = 0;
    private bool _isSpinTurn = false;
    private bool _isSafeOrSuperZone = false;

    public void Initialize(LevelManager levelManager)
    {
        _levelManager = levelManager;

        CheckActiveExitButton();
    }

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(ActiveExitPanel);
        EventManager.Subscribe(GameEvents.OnStartSpinTurn, SetSpinTurnTrue);
        EventManager.Subscribe(GameEvents.OnEndSpinTurn, SetSpinTurnFalse);
        EventManager.Subscribe(GameEvents.OnGiveUp, ResetRewardItems);
        EventManager.Subscribe(GameEvents.OnCollectRewards, ResetRewardItems);
        EventManager<SliceData>.Subscribe(GameEvents.OnEarnReward, AddReward);
    }
    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(ActiveExitPanel);
        EventManager.Unsubscribe(GameEvents.OnStartSpinTurn, SetSpinTurnTrue);
        EventManager.Unsubscribe(GameEvents.OnEndSpinTurn, SetSpinTurnFalse);
        EventManager.Unsubscribe(GameEvents.OnGiveUp, ResetRewardItems);
        EventManager.Unsubscribe(GameEvents.OnCollectRewards, ResetRewardItems);
        EventManager<SliceData>.Unsubscribe(GameEvents.OnEarnReward, AddReward);
    }

    private void CheckActiveExitButton()
    {
        _isSafeOrSuperZone = _levelManager.GetLevelType() != LevelType.Default;

        if (!_isSpinTurn && _isSafeOrSuperZone)
        {
            _exitButton.enabled = true;
        }
        else
        {
            _exitButton.enabled = false;
        }
    }

    public void AddReward(SliceData slicedData)
    {
        if (slicedData.sliceType == TypesOfSlice.Death)
        {
            return;
        }

        if (!_rewards.ContainsKey(slicedData.sliceType))
        {
            _rewards.Add(slicedData.sliceType, _rewardIndex);
            _rewardManagersRewardPanel[_rewardIndex].SetSliceDatas(slicedData);
            _rewardManagersExitPanel[_rewardIndex].SetSliceDatas(slicedData);
            _rewardIndex++;
            IncreaseHeight();
        }
        else
        {
            _rewardManagersRewardPanel[_rewards[slicedData.sliceType]].SetSliceDatas(slicedData);
            _rewardManagersExitPanel[_rewards[slicedData.sliceType]].SetSliceDatas(slicedData);
        }

    }

    private void ResetRewardItems()
    {
        for (int i = 0; i < _rewardIndex; i++)
        {
            _rewardManagersRewardPanel[i].ResetRewardItem();
            _rewardManagersExitPanel[i].ResetRewardItem();
        }

        _rewards.Clear();

        _rewardIndex = 0;
    }

    public void IncreaseHeight()
    {
        Vector2 size = _container.sizeDelta;

        size.y += 45;

        _container.sizeDelta = size;
    }

    private void ActiveExitPanel()
    {
        _exitPanel.SetActive(true);
    }

    private void SetSpinTurnTrue()
    {
        _isSpinTurn = true;

        CheckActiveExitButton();
    }
    private void SetSpinTurnFalse()
    {
        _isSpinTurn = false;

        CheckActiveExitButton();
    }
}
