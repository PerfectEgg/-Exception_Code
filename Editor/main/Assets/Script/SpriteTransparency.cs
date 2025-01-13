using UnityEngine;

public class SpriteTransparency : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // SpriteRenderer ������Ʈ ��������
        spriteRenderer = GetComponent<SpriteRenderer>();

        // �̹����� ���� ���� (���� �� ����)
        Color color = spriteRenderer.color;
        color.a = 0f;  // 0�� ���� ����, 1�� ������
        spriteRenderer.color = color;
    }
}