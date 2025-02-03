using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SongLoader : MonoBehaviour
{
    public TMP_InputField songFileNameInputField;  // ���� �̸� �Է� �ʵ�
    public GameObject beatSpritePrefab;  // ���� ǥ���� ��������Ʈ
    public GameObject measurePrefab;
    public GameObject parentMeasure;
    public GameObject lines;
    public ScrollRect scrollRect;
    public Transform beatContainer;  // ��������Ʈ�� ��ġ�� �θ� ��ü

    private float total_Length = 0;
    private int bpm;
    private int songLength;
    private string song;


    // �뷡�� �ҷ����� ��ư�� ������ �� ȣ��Ǵ� �Լ�
    public void LoadSong(string songName)
    {
        song = songName;
        
        // ���� �̸����� BPM�� ���̸� �����ϴ� ���� (���� ǥ������ ���)
        bpm = ExtractBPM();
        songLength = ExtractSongLength();

        if (bpm > 0 && songLength > 0)
        {
            // �� ���� �� ���
            float totalBeats = songLength * bpm;  // �� ���� ��
            float totalMeasures = totalBeats / 4; // 1���� 4����

            total_Length = totalMeasures * 8.5f;

            // ȭ�鿡 ���� ��������Ʈ ����
            SetMeasures(totalMeasures);
        }
        else
        {
            Debug.LogError("BPM or Song Length not found in file name!");
        }
    }

    // BPM�� ���� �̸����� �����ϴ� �Լ� (���Խ� ���)
    private int ExtractBPM()
    {
        string bpmPattern = @"(\d+)(?=bpm)";  // 'bpm' �տ� �ִ� ���ڸ� ����
        System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(song, bpmPattern);
        if (match.Success)
        {
            return int.Parse(match.Value);
        }
        return 0;
    }

    // �� ���̸� ���� �̸����� �����ϴ� �Լ� (���Խ� ���)
    private int ExtractSongLength()
    {
        string lengthPattern = @"(\d+)(?=s)";  // 's' �տ� �ִ� ���ڸ� ����
        System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(song, lengthPattern);
        if (match.Success)
        {
            return int.Parse(match.Value);
        }
        return 0;
    }

    // �� ���� ���� �°� ���� ��������Ʈ�� ȭ�鿡 ���� �Լ�
    private void SetMeasures(float totalMeasures)
    {
        // ������ ������ ���� ��������Ʈ�� �ʱ�ȭ
        foreach (Transform child in beatContainer)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < totalMeasures; i++)
        {
            float screenHeight = scrollRect.viewport.rect.height;  // ��ũ�� ��ũƮ ����Ʈ�� ����
            float measureHeight = screenHeight / totalMeasures;  // ���� �� ���� ����
            float lineHeight = screenHeight; // ���� �ϳ�.

            // ���� ����
            GameObject line = Instantiate(lines);
            line.transform.SetParent(parentMeasure.transform, false);  // �θ� ������Ʈ�� �ڽ����� �߰�

            // ���� ��ġ ����
            RectTransform lineRect = line.GetComponent<RectTransform>();
            lineRect.anchoredPosition = new Vector2(0, i * 8.5f);  // ������ y ��ǥ ���
            lineRect.sizeDelta = new Vector2(lines.GetComponent<RectTransform>().rect.width, lineHeight);  // ������ ũ�� ����

            // ���� ����
            GameObject measure = Instantiate(measurePrefab);
            measure.transform.SetParent(parentMeasure.transform, false);  // �θ� ������Ʈ�� �ڽ����� �߰�

            // ���� ��ġ ����
            RectTransform measureRect = measure.GetComponent<RectTransform>();
            measureRect.anchoredPosition = new Vector2(0.1f, -0.525f + i * 8.5f);  // ������ y ��ǥ ���
            measureRect.sizeDelta = new Vector2(lines.GetComponent<RectTransform>().rect.width, lineHeight);  // ���� ũ�� ����
        }
    }
}