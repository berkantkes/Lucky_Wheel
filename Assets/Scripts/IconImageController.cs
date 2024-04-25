using UnityEngine;
using UnityEngine.UI;

public class IconImageController : MonoBehaviour
{
    [SerializeField] private Image _iconImage;

    public void SetSprite(Sprite iconSprite)
    {
        _iconImage.sprite = iconSprite;
    }
}
