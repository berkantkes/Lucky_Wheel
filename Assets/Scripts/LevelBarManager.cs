using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelBarManager : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _levelTexts;
    [SerializeField] private Transform _levelTextsParentTransform;

    private int _xSpacing = 80;
    private float _levelTextMoveDuration = 1;

    public void Instant()
    {
        for (int i = 0; i < _levelTexts.Count; i++)
        {
            _levelTexts[i].SetText((i + 1).ToString());
            _levelTexts[i].transform.localPosition = new Vector3(i * _xSpacing, 0, 0);

            if ((i + 1) % 30 == 0)
            {
                _levelTexts[i].color = Color.blue;
                continue;
            }
            if ((i + 1) % 5 == 0)
            {
                _levelTexts[i].color = Color.green;
                continue;
            }
        }
    }

    public void LevelUp()
    {
        _levelTextsParentTransform.DOMoveX(_levelTextsParentTransform.position.x - _xSpacing, _levelTextMoveDuration)
            .SetEase(Ease.InOutCubic);
    }
}
