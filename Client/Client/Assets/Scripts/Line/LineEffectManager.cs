using UnityEngine;

public class LineEffect : MonoBehaviour
{
    public int lineIndex;  // �� ������ �ε���
    public KeyCode lineKey;  // �� ���ο� �ش��ϴ� Ű
    private SpriteRenderer spriteRenderer;  // ������ SpriteRenderer
    public Color effectColor = new Color(1f, 1f, 0.8f, 1f);  // ���� ����� (RGBA)
    public float effectDuration = 0.2f;  // ����Ʈ ���� �ð� (�� �κ��� ����� �Է��� ������ �� �۵�)

    private bool isEffectActive = false;  // ����Ʈ�� Ȱ��ȭ�Ǿ����� ����

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);  // �ʱ⿡�� ���� ���·� ����
    }

    // �ܺο��� Ű�� �����ϴ� �޼���
    public void SetLineKey(KeyCode key)
    {
        lineKey = key;
    }

    void Update()
    {
        // Ű�� ��� ������ �ִ� ���� ����Ʈ Ȱ��ȭ
        if (Input.GetKey(lineKey) && !isEffectActive)
        {
            ActivateEffect();
        }
        // Ű�� �������� �� ����Ʈ ��Ȱ��ȭ
        else if (!Input.GetKey(lineKey) && isEffectActive)
        {
            DeactivateEffect();
        }
    }

    public void ActivateEffect()
    {
        // ����Ʈ�� Ȱ��ȭ�ϰ�, ������ ����
        spriteRenderer.color = effectColor;

        // ����Ʈ�� Ȱ��ȭ�� �� ���� ����
        isEffectActive = true;

        // ������ ũ�⿡ �°� ����Ʈ ũ�� ���� (��������Ʈ ũ�� ����)
        transform.localScale = new Vector3(1f, 1f, 1f);  // ���ϴ� ũ��� ����
    }

    public void DeactivateEffect()
    {
        // ����Ʈ�� ��Ȱ��ȭ
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);  // �����ϰ� �����
        isEffectActive = false;

        // ����Ʈ ũ�� ���� (�ʿ��)
        transform.localScale = new Vector3(1f, 1f, 1f);  // �⺻ ũ�� ���� (�ʿ信 ���� ����)
    }
}
