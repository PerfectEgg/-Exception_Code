using UnityEngine;
using UnityEngine.UI;

public class BackgroundImageSetter : MonoBehaviour
{
    public Image backgroundImage;  // 배경 이미지를 표시할 UI Image 컴포넌트
    public Sprite backgroundSprite; // 배경 이미지로 사용할 Sprite

    void Start()
    {
        // 배경 이미지 슬롯에 이미지가 있다면 설정
        if (backgroundImage != null && backgroundSprite != null)
        {
            backgroundImage.sprite = backgroundSprite;  // Sprite 할당
        }

        if (backgroundImage != null)
        {
            // 회색 배경 설정
            backgroundImage.color = new Color(0.66f, 0.66f, 0.66f);  // RGB: 169, 169, 169
        }
        else
        {
            Debug.LogError("Background Image is not assigned!");
        }
    }
}