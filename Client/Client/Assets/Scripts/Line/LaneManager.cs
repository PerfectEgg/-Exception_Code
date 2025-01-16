using UnityEngine;

public class LineManager : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;  // GameSettings ���� (Inspector���� ����)
    public GameObject linesParent;  // ��� ���� ������Ʈ�� ���� �θ� ������Ʈ (lines)
    private LineEffect[] lineEffects;  // ���κ� ȿ���� ������ �迭

    void Start()
    {
        if (gameSettings == null)
        {
            Debug.LogError("LineManager: GameSettings not assigned!");
            return;
        }

        // linesParent���� ��� LineEffect ������Ʈ�� ã�Ƽ� �迭�� ����
        lineEffects = linesParent.GetComponentsInChildren<LineEffect>();

        // �� LineEffect�� Ű ������ ����
        for (int i = 0; i < lineEffects.Length; i++)
        {
            if (i < gameSettings.lineKeys.Length)
            {
                lineEffects[i].SetLineKey(gameSettings.lineKeys[i]);  // �� ������ Ű ����
            }
            else
            {
                Debug.LogWarning("LineManager: lineKeys array length doesn't match lines count.");
            }
        }
    }

    void Update()
    {
        // �� LineEffect�� Ȱ��ȭ�� �� �ֵ��� ó��
        for (int i = 0; i < lineEffects.Length; i++)
        {
            if (Input.GetKeyDown(lineEffects[i].lineKey))
            {
                lineEffects[i].ActivateEffect();
            }
        }
    }

    // LineEffect�� Ű�� ��û�ϴ� �޼���
    public KeyCode GetLineKey(int lineIndex)
    {
        if (lineIndex >= 0 && lineIndex < gameSettings.lineKeys.Length)
        {
            return gameSettings.lineKeys[lineIndex];
        }
        return KeyCode.None;  // �⺻��
    }
}
