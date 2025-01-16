using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings")]
public class GameSettings : ScriptableObject
{
    public KeyCode[] lineKeys = new KeyCode[4]; // 라인별 키를 저장 (예: 4개의 레인에 대응하는 키)

    public void SetDefaultKeys()
    {
        // 기본 키 설정 (임의로 설정)
        lineKeys[0] = KeyCode.A;  // 첫 번째 레인 (A 키)
        lineKeys[1] = KeyCode.S;  // 두 번째 레인 (S 키)
        lineKeys[2] = KeyCode.K;  // 세 번째 레인 (K 키)
        lineKeys[3] = KeyCode.L;  // 네 번째 레인 (L 키)
    }
}
