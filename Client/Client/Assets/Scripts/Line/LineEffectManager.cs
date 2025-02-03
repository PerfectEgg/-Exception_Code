using UnityEngine;

public class LineEffect : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;  // ���� ����Ʈ�� SpriteRenderer
    public Color effectColor = new Color(1f, 1f, 0.8f, 1f);  // ���� �����
    private bool isEffectActive = false;  // ����Ʈ�� Ȱ��ȭ �������� ����

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);  // �ʱ⿡�� ����
    }

    // ����Ʈ Ȱ��ȭ
    public void ActivateEffect()
    {
        if (isEffectActive) return;  // �̹� Ȱ��ȭ�� ��� �ߺ� ���� ����
        spriteRenderer.color = effectColor;
        isEffectActive = true;
    }

    // ����Ʈ ��Ȱ��ȭ
    public void DeactivateEffect()
    {
        if (!isEffectActive) return;
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);  // �����ϰ� ����
        isEffectActive = false;
    }
}
