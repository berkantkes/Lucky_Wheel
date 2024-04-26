using UnityEngine;
using UnityEngine.UI;

public class ImageScaler : MonoBehaviour
{

    public Image imageComponent;
    public float targetWidth = 800f;
    public float targetHeight = 800f;

    private static ImageScaler _instance;
    public static ImageScaler Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ImageScaler();
            }
            return _instance;
        }
    }

    public void SetImageSize(Sprite sprite, RectTransform rectTransform)
    {
        float originalWidth = sprite.rect.width / sprite.pixelsPerUnit;
        float originalHeight = sprite.rect.height / sprite.pixelsPerUnit;

        float widthScaleFactor = targetWidth / originalWidth;
        float heightScaleFactor = targetHeight / originalHeight;

        float scaleFactor = Mathf.Min(widthScaleFactor, heightScaleFactor);
        float newWidth = originalWidth * scaleFactor;
        float newHeight = originalHeight * scaleFactor;

        rectTransform.sizeDelta = new Vector2(newWidth, newHeight);
    }
}
