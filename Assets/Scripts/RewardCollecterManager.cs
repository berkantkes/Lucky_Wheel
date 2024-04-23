using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardCollecterManager : MonoBehaviour
{
    private static RewardCollecterManager instance;

    [SerializeField] private List<RewardManager> _rewardManagers = new List<RewardManager>();

    private Dictionary<SlicedTypes, int> _rewards = new Dictionary<SlicedTypes, int>();

    private int _rewardIndex = 0;

    private RewardCollecterManager() { }

    public static RewardCollecterManager GetInstance()
    {
        if (instance == null)
        {
            instance = new RewardCollecterManager();
        }
        return instance;
    }

    public void AddReward(SlicedData slicedData)
    {
        if (slicedData.slicedType == SlicedTypes.Death)
        {
            // death sequence
        }

        if (!_rewards.ContainsKey(slicedData.slicedType))
        {
            _rewards.Add(slicedData.slicedType, _rewardIndex);
            _rewardManagers[_rewardIndex].SetSliceDatas(slicedData);
            _rewardIndex++;
        }
        else
        {
            _rewardManagers[_rewards[slicedData.slicedType]].SetSliceDatas(slicedData);
        }
    }

}
