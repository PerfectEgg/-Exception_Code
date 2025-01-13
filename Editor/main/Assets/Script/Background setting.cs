using UnityEngine;
using UnityEngine.UI;

public class BackgroundImageSetter : MonoBehaviour
{
    public Image backgroundImage;  // ��� �̹����� ǥ���� UI Image ������Ʈ
    public Sprite backgroundSprite; // ��� �̹����� ����� Sprite

    void Start()
    {
        // ��� �̹��� ���Կ� �̹����� �ִٸ� ����
        if (backgroundImage != null && backgroundSprite != null)
        {
            backgroundImage.sprite = backgroundSprite;  // Sprite �Ҵ�
        }

        if (backgroundImage != null)
        {
            // ȸ�� ��� ����
            backgroundImage.color = new Color(0.66f, 0.66f, 0.66f);  // RGB: 169, 169, 169
        }
        else
        {
            Debug.LogError("Background Image is not assigned!");
        }
    }
}