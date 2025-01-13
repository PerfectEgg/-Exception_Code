using UnityEngine;
using UnityEngine.UI;

public class BackgroundColorChanger : MonoBehaviour
{
    public Image backgroundImage;  // Image ������Ʈ�� �巡���Ͽ� ����

    void Start()
    {
        // backgroundImage�� �Ҵ�Ǿ����� üũ
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