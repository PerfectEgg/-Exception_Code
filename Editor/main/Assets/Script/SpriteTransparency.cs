using UnityEngine;

public class SpriteTransparency : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // SpriteRenderer 컴포넌트 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 이미지의 투명도 조정 (알파 값 조정)
        Color color = spriteRenderer.color;
        color.a = 0f;  // 0은 완전 투명, 1은 불투명
        spriteRenderer.color = color;
    }
}