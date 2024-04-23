using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelsData _levelsData;
    [SerializeField] private SpinTurn _spinTurn;
    [SerializeField] private UiImageSelect _uiImageSelect;
    [SerializeField] private LevelBarManager _levelBarManager;

    private int _currentLevel = 1;

    private void Start()
    {
        _uiImageSelect.CreateDictionary();
        _spinTurn.Instant(_levelsData.luckyWheelDatas[_currentLevel - 1], this);
        _levelBarManager.Instant();
    }

    public void LevelUp()
    {
        _currentLevel++;
        _levelBarManager.LevelUp();
        _spinTurn.LoadLevel(_levelsData.luckyWheelDatas[_currentLevel - 1]);
        //LevelBar leve text bakcground set
    }

}
