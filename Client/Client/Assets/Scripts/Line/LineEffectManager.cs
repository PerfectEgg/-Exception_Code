using UnityEngine;

public class LineEffect : MonoBehaviour
{
    public int lineIndex;  // 이 라인의 인덱스
    public KeyCode lineKey;  // 이 라인에 해당하는 키
    private SpriteRenderer spriteRenderer;  // 라인의 SpriteRenderer
    public Color effectColor = new Color(1f, 1f, 0.8f, 1f);  // 연한 노란색 (RGBA)
    public float effectDuration = 0.2f;  // 이팩트 지속 시간 (이 부분은 사용자 입력이 끊겼을 때 작동)

    private bool isEffectActive = false;  // 이팩트가 활성화되었는지 여부

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);  // 초기에는 투명 상태로 설정
    }

    // 외부에서 키를 설정하는 메서드
    public void SetLineKey(KeyCode key)
    {
        lineKey = key;
    }

    void Update()
    {
        // 키를 계속 누르고 있는 동안 이팩트 활성화
        if (Input.GetKey(lineKey) && !isEffectActive)
        {
            ActivateEffect();
        }
        // 키가 떼어졌을 때 이팩트 비활성화
        else if (!Input.GetKey(lineKey) && isEffectActive)
        {
            DeactivateEffect();
        }
    }

    public void ActivateEffect()
    {
        // 이팩트를 활성화하고, 색상을 적용
        spriteRenderer.color = effectColor;

        // 이팩트가 활성화된 후 상태 갱신
        isEffectActive = true;

        // 라인의 크기에 맞게 이팩트 크기 설정 (스프라이트 크기 조정)
        transform.localScale = new Vector3(1f, 1f, 1f);  // 원하는 크기로 조정
    }

    public void DeactivateEffect()
    {
        // 이팩트를 비활성화
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);  // 투명하게 만들기
        isEffectActive = false;

        // 이팩트 크기 복원 (필요시)
        transform.localScale = new Vector3(1f, 1f, 1f);  // 기본 크기 복원 (필요에 따라 수정)
    }
}
