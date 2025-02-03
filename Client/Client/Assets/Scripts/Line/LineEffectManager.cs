using UnityEngine;

public class LineEffect : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;  // 레인 이팩트의 SpriteRenderer
    public Color effectColor = new Color(1f, 1f, 0.8f, 1f);  // 연한 노란색
    private bool isEffectActive = false;  // 이팩트가 활성화 상태인지 여부

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);  // 초기에는 투명
    }

    // 이팩트 활성화
    public void ActivateEffect()
    {
        if (isEffectActive) return;  // 이미 활성화된 경우 중복 실행 방지
        spriteRenderer.color = effectColor;
        isEffectActive = true;
    }

    // 이팩트 비활성화
    public void DeactivateEffect()
    {
        if (!isEffectActive) return;
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);  // 투명하게 설정
        isEffectActive = false;
    }
}
