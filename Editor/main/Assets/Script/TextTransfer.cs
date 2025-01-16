using UnityEngine;
using UnityEngine.UI;  // UI 관련 기능을 사용하기 위해 필요

public class TextTransfer : MonoBehaviour
{
    public InputField songInputField;  // 입력받을 텍스트 필드
    public Text songNameText;          // 값을 넣을 텍스트 (GameObject의 텍스트 컴포넌트)

    // 버튼 클릭 시 호출될 함수
    public void TransferText()
    {
        if (songInputField != null && songNameText != null)
        {
            songNameText.text = songInputField.text;  // InputField의 텍스트 값을 가져와서 텍스트에 넣기
            Debug.Log("Transferred text: " + songInputField.text);  // 디버깅용 로그 출력
        }
    }
}