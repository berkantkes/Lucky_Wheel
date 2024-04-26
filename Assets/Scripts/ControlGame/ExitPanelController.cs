using UnityEngine;
using UnityEngine.UI;

public class ExitPanelController : MonoBehaviour
{
    [SerializeField] private Button _collectRewardReferences;
    [SerializeField] private Button _goBackReferences;

    private Button _collectReward;
    private Button _goBack;

    private void OnValidate()
    {
        _collectReward = _collectRewardReferences; 
        _goBack = _goBackReferences;
    }

    private void OnEnable()
    {
        _collectReward.onClick.AddListener(CollectReward);
        _goBack.onClick.AddListener(GoBack);
    }

    private void OnDisable()
    {
        _collectReward.onClick.RemoveListener(CollectReward);
        _goBack.onClick.RemoveListener(GoBack);
    }

    private void CollectReward()
    {
        EventManager.Execute(GameEvents.OnCollectRewards);
        gameObject.SetActive(false);
    }
    private void GoBack()
    {
        gameObject.SetActive(false);
    }
}
