using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelsData", menuName = "ScriptableObjects/LevelsData")]
public class LevelsData : ScriptableObject
{

    public List<LuckyWheelData> luckyWheelDatas = new List<LuckyWheelData>();
}
