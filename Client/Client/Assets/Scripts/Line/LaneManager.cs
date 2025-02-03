using UnityEngine;
using UnityEngine.InputSystem;

public class LineManager : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;  // GameSettings ���� (Inspector���� ����)
    public GameObject linesParent;  // ��� ���� ������Ʈ�� ���� �θ� ������Ʈ (lines)
    public GameObject effectsParent;  // ��� ����Ʈ ������Ʈ�� ���� �θ� ������Ʈ (effects)
    public InputAction[] lineActions; // ���ο� Input System���� Ű �Է� ����

    private LineEffect[] lineEffects;  // ���κ� ����Ʈ
    private KeyCode[] lineKeys;  // Ű ����

    void Start()
    {
        if (gameSettings == null)
        {
            Debug.LogError("LineManager: GameSettings not assigned!");
            return;
        }

        // linesParent���� ��� LineEffect ã��
        lineEffects = effectsParent.GetComponentsInChildren<LineEffect>();
        lineKeys = gameSettings.lineKeys;  // Ű ���� �ε�

        if (lineEffects.Length != lineKeys.Length)
        {
            Debug.LogError("LineManager: LineEffect ������ Ű ������ ���� �ʽ��ϴ�!");
        }
    }

    void Awake()
    {
        foreach (var action in lineActions)
        {
            action.Enable();  // �Է� Ȱ��ȭ
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
            if (!Input.GetKey(lineKeys[i]))  // Ű�� ���� ���� ������ ������ ����Ʈ ����
            {   
                lineEffects[i].DeactivateEffect();
            }
        }
    }
}
