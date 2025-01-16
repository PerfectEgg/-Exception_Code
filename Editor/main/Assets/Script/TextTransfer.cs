using UnityEngine;
using UnityEngine.UI;  // UI ���� ����� ����ϱ� ���� �ʿ�

public class TextTransfer : MonoBehaviour
{
    public InputField songInputField;  // �Է¹��� �ؽ�Ʈ �ʵ�
    public Text songNameText;          // ���� ���� �ؽ�Ʈ (GameObject�� �ؽ�Ʈ ������Ʈ)

    // ��ư Ŭ�� �� ȣ��� �Լ�
    public void TransferText()
    {
        if (songInputField != null && songNameText != null)
        {
            songNameText.text = songInputField.text;  // InputField�� �ؽ�Ʈ ���� �����ͼ� �ؽ�Ʈ�� �ֱ�
            Debug.Log("Transferred text: " + songInputField.text);  // ������ �α� ���
        }
    }
}