using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSlicedManager : MonoBehaviour
{
    [SerializeField] private List<SliceManager> _sliceManagers = new List<SliceManager>();

    public void SetSlicedsData(List<SliceData> sliceDatas)
    {
        for (int i = 0; i < _sliceManagers.Count; i++)
        {
            _sliceManagers[i].SetSliceDatas(sliceDatas[i]);
        }
    }
}
