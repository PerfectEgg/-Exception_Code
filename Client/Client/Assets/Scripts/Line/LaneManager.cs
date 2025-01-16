using UnityEngine;

public class LineManager : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;  // GameSettings 참조 (Inspector에서 연결)
    public GameObject linesParent;  // 모든 라인 오브젝트를 묶은 부모 오브젝트 (lines)
    private LineEffect[] lineEffects;  // 라인별 효과를 관리할 배열

    void Start()
    {
        if (gameSettings == null)
        {
            Debug.LogError("LineManager: GameSettings not assigned!");
            return;
        }

        // linesParent에서 모든 LineEffect 컴포넌트를 찾아서 배열로 저장
        lineEffects = linesParent.GetComponentsInChildren<LineEffect>();

        // 각 LineEffect에 키 정보를 전달
        for (int i = 0; i < lineEffects.Length; i++)
        {
            if (i < gameSettings.lineKeys.Length)
            {
                lineEffects[i].SetLineKey(gameSettings.lineKeys[i]);  // 각 라인의 키 설정
            }
            else
            {
                Debug.LogWarning("LineManager: lineKeys array length doesn't match lines count.");
            }
        }
    }

    void Update()
    {
        // 각 LineEffect가 활성화될 수 있도록 처리
        for (int i = 0; i < lineEffects.Length; i++)
        {
            if (Input.GetKeyDown(lineEffects[i].lineKey))
            {
                lineEffects[i].ActivateEffect();
            }
        }
    }

    // LineEffect가 키를 요청하는 메서드
    public KeyCode GetLineKey(int lineIndex)
    {
        if (lineIndex >= 0 && lineIndex < gameSettings.lineKeys.Length)
        {
            return gameSettings.lineKeys[lineIndex];
        }
        return KeyCode.None;  // 기본값
    }
}
