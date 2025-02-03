using UnityEngine;
using UnityEngine.InputSystem;

public class LineManager : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;  // GameSettings 참조 (Inspector에서 연결)
    public GameObject linesParent;  // 모든 라인 오브젝트를 묶은 부모 오브젝트 (lines)
    public GameObject effectsParent;  // 모든 이팩트 오브젝트를 묶은 부모 오브젝트 (effects)
    public InputAction[] lineActions; // 새로운 Input System에서 키 입력 관리

    private LineEffect[] lineEffects;  // 라인별 이팩트
    private KeyCode[] lineKeys;  // 키 매핑

    void Start()
    {
        if (gameSettings == null)
        {
            Debug.LogError("LineManager: GameSettings not assigned!");
            return;
        }

        // linesParent에서 모든 LineEffect 찾기
        lineEffects = effectsParent.GetComponentsInChildren<LineEffect>();
        lineKeys = gameSettings.lineKeys;  // 키 설정 로드

        if (lineEffects.Length != lineKeys.Length)
        {
            Debug.LogError("LineManager: LineEffect 개수와 키 개수가 맞지 않습니다!");
        }
    }

    void Awake()
    {
        foreach (var action in lineActions)
        {
            action.Enable();  // 입력 활성화
        }
    }

    void Update()
    {
        for (int i = 0; i < lineEffects.Length; i++)
        {
            if (Input.GetKey(lineKeys[i]))
            {
                lineEffects[i].ActivateEffect();
            }
        }
    }

    void LateUpdate()
    {
        for (int i = 0; i < lineEffects.Length; i++)
        {
            if (!Input.GetKey(lineKeys[i]))  // 키가 눌려 있지 않으면 강제로 이팩트 해제
            {   
                lineEffects[i].DeactivateEffect();
            }
        }
    }
}
