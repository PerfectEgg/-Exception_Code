using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings")]
public class GameSettings : ScriptableObject
{
    public KeyCode[] lineKeys = new KeyCode[4]; // ���κ� Ű�� ���� (��: 4���� ���ο� �����ϴ� Ű)

    public void SetDefaultKeys()
    {
        // �⺻ Ű ���� (���Ƿ� ����)
        lineKeys[0] = KeyCode.A;  // ù ��° ���� (A Ű)
        lineKeys[1] = KeyCode.S;  // �� ��° ���� (S Ű)
        lineKeys[2] = KeyCode.K;  // �� ��° ���� (K Ű)
        lineKeys[3] = KeyCode.L;  // �� ��° ���� (L Ű)
    }
}
