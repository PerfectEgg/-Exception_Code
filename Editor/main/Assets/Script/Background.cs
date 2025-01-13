using UnityEngine;
using UnityEngine.UI;

public class BackgroundColorChanger : MonoBehaviour
{
    public Image backgroundImage;  // Image 컴포넌트를 드래그하여 연결

    void Start()
    {
        // backgroundImage가 할당되었는지 체크
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