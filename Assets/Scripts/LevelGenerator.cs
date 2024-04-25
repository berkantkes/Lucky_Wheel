using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private LevelsData _levelsData;
    [SerializeField] private SpinSlicedManager _spinSlicedManager;
    [SerializeField] private SpinController _spinController;

    private List<SlicedRateData> _slicesRateData = new List<SlicedRateData>();
    List<SlicedRateData> _selectedSlicedTypesDatas = new List<SlicedRateData>();
    List<SliceData> _sliceDatas = new List<SliceData>();
    private LevelManager _levelManager;

    private int _availableSlicesCount = 8;
    private int _currentLevel = 1;
    public void Initialize(SpinController spinController, LevelManager levelManager)
    {
        _levelManager = levelManager;
        _spinController = spinController;
        _spinController.Initialize(_levelManager);
    }

    public void LoadLevel(int currentLevel, LevelType levelType)
    {
        _currentLevel = currentLevel;
        _availableSlicesCount = 8;

        LuckyWheelRateData luckyWheelRateData = _levelsData.luckyWheelDatas[_currentLevel - 1];

        _slicesRateData.Clear();
        _selectedSlicedTypesDatas.Clear();
        _sliceDatas.Clear();
        _slicesRateData.AddRange(luckyWheelRateData.SlicesRateData);

        CheckDeathLevel(levelType);
        DetectSlicesTypes();
        DetectSlicesAmounts();

        _sliceDatas = ShuffleList(_sliceDatas);
        _spinSlicedManager.SetSlicedsData(_sliceDatas);
        _spinController.ResetSpinBase();
        _spinController.SetSliceData(_sliceDatas);
    }

    private void CheckDeathLevel(LevelType levelType)
    {
        if (levelType == LevelType.Default)
        {
            SliceData newSliceData = new SliceData();
            newSliceData.amount = 0;
            newSliceData.sliceType = TypesOfSlice.Death;
            _sliceDatas.Add(newSliceData);
            _availableSlicesCount--;
        }
    }

    private void DetectSlicesTypes()
    {
        for (int i = 0; i < _availableSlicesCount; i++)
        {
            Debug.Log(_selectedSlicedTypesDatas.Count);
            Debug.Log(_slicesRateData.Count);
            SlicedRateData selectedData = ChooseRandomData();

            _selectedSlicedTypesDatas.Add(selectedData);

            _slicesRateData.Remove(selectedData);
        }
    }

    private SlicedRateData ChooseRandomData()
    {
        List<Range> ranges = CalculateRanges();

        int randomValue = UnityEngine.Random.Range(0, ranges[ranges.Count - 1].End);

        foreach (Range range in ranges)
        {
            if (randomValue >= range.Start && randomValue < range.End)
            {
                return range.Data;
            }
        }

        return _slicesRateData[_slicesRateData.Count - 1];
    }

    private List<Range> CalculateRanges()
    {
        List<Range> ranges = new List<Range>();
        int start = 0;
        foreach (SlicedRateData data in _slicesRateData)
        {
            int end = start + (int)data.rate;
            ranges.Add(new Range(start, end, data));
            start = end;
        }
        return ranges;
    }

    private void DetectSlicesAmounts()
    {
        foreach (var item in _selectedSlicedTypesDatas)
        {
            SliceData newSliceData = new SliceData();
            newSliceData.amount = GetSlicesAmounts(item.sliceType);
            newSliceData.sliceType = item.sliceType;
            _sliceDatas.Add(newSliceData);
        }
    }

    private int GetSlicesAmounts(TypesOfSlice sliceType)
    {
        int amount = 0;

        GeneralTypesOfSlice generalTypesOfSlice = UiImageSelect.GetSlicedGeneralTypes(sliceType);

        switch (generalTypesOfSlice)
        {
            case GeneralTypesOfSlice.Gold:
                amount = _currentLevel * UnityEngine.Random.Range(2, 5);
                break;
            case GeneralTypesOfSlice.ItemPoints:
                amount = _currentLevel * UnityEngine.Random.Range(20, 40);
                break;
            case GeneralTypesOfSlice.Cash:
                amount = _currentLevel * UnityEngine.Random.Range(100, 1000);
                break;
            case GeneralTypesOfSlice.Weapon:
                amount = _currentLevel * UnityEngine.Random.Range(1, 2);
                break;
            case GeneralTypesOfSlice.Chest:
                amount = _currentLevel * UnityEngine.Random.Range(1, 4);
                break;
            case GeneralTypesOfSlice.Supportive:
                amount = _currentLevel * UnityEngine.Random.Range(10, 20);
                break;
            case GeneralTypesOfSlice.Death:
                amount = 0;
                break;
        }

        return amount;
    }

    private class Range
    {
        public int Start { get; private set; }
        public int End { get; private set; }
        public SlicedRateData Data { get; private set; }

        public Range(int start, int end, SlicedRateData data)
        {
            Start = start;
            End = end;
            Data = data;
        }
    }

    private List<T> ShuffleList<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        return list;
    }
}
