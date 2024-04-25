using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private SpinController _spinController;
    [SerializeField] private UiImageSelect _uiImageSelect;
    [SerializeField] private LevelBarManager _levelBarManager;
    [SerializeField] private SpinBaseController _spinBaseController;
    [SerializeField] private EarnCardController _earnCardController;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private RewardCollecterManager _rewardCollecterManager;

    private int _currentLevel = 1;

    private void Start()
    {
        _uiImageSelect.Initialize();
        _levelBarManager.Initialize(this);
        _rewardCollecterManager.Initialize(this);
        _levelGenerator.Initialize(_spinController, this);

        _levelGenerator.LoadLevel(_currentLevel, GetLevelType(_currentLevel));
    }

    private void OnEnable()
    {
        EventManager.Subscribe(GameEvents.OnGiveUp, ResetLevel);
        EventManager.Subscribe(GameEvents.OnCollectRewards, ResetLevel);
    }

    private void OnDisable()
    {
        EventManager.Unsubscribe(GameEvents.OnGiveUp, ResetLevel);
        EventManager.Unsubscribe(GameEvents.OnCollectRewards, ResetLevel);
    }

    public void LevelUp(SliceData slicedData)
    {
        _currentLevel++;
        LevelType levelType = GetLevelType(_currentLevel);

        _levelBarManager.LevelUp(levelType);
        _levelGenerator.LoadLevel(_currentLevel,levelType);
        _spinController.SetSpinButtonEnable(true);
        _spinBaseController.SetSpinBaseImage(levelType);
        _earnCardController.SetAndActivateEarnCard(slicedData);
    }

    public void DeathCard(SliceData slicedData)
    {
        _earnCardController.DeathCard(slicedData);
    }

    public void ResetLevel()
    {
        _currentLevel = 1;
        LevelType levelType = GetLevelType(_currentLevel);

        _levelGenerator.LoadLevel(_currentLevel, levelType);
        _spinBaseController.SetSpinBaseImage(levelType);
    }

    public LevelType GetLevelType(int level)
    {
        if (level % 30 == 0)
        {
            return LevelType.SuperZone;
        }
        else if (level % 5 == 0)
        {
            return LevelType.SafeZone;
        }
        else
        {
            return LevelType.Default;
        }
    }
    public LevelType GetLevelType()
    {
        if (_currentLevel % 30 == 0)
        {
            return LevelType.SuperZone;
        }
        else if (_currentLevel % 5 == 0)
        {
            return LevelType.SafeZone;
        }
        else
        {
            return LevelType.Default;
        }
    }

}

public enum LevelType
{
    Default,
    SafeZone,
    SuperZone
}
