using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SongLoader : MonoBehaviour
{
    public TMP_InputField songFileNameInputField;  // 파일 이름 입력 필드
    public GameObject beatSpritePrefab;  // 마디를 표시할 스프라이트
    public GameObject measurePrefab;
    public GameObject parentMeasure;
    public GameObject lines;
    public ScrollRect scrollRect;
    public Transform beatContainer;  // 스프라이트를 배치할 부모 객체

    private float total_Length = 0;
    private int bpm;
    private int songLength;
    private string song;


    // 노래를 불러오기 버튼을 눌렀을 때 호출되는 함수
    public void LoadSong(string songName)
    {
        song = songName;
        
        // 파일 이름에서 BPM과 길이를 추출하는 예시 (정규 표현식을 사용)
        bpm = ExtractBPM();
        songLength = ExtractSongLength();

        if (bpm > 0 && songLength > 0)
        {
            // 총 마디 수 계산
            float totalBeats = songLength * bpm;  // 총 박자 수
            float totalMeasures = totalBeats / 4; // 1마디에 4박자

            total_Length = totalMeasures * 8.5f;

            // 화면에 마디 스프라이트 띄우기
            SetMeasures(totalMeasures);
        }
        else
        {
            Debug.LogError("BPM or Song Length not found in file name!");
        }
    }

    // BPM을 파일 이름에서 추출하는 함수 (정규식 사용)
    private int ExtractBPM()
    {
        string bpmPattern = @"(\d+)(?=bpm)";  // 'bpm' 앞에 있는 숫자를 추출
        System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(song, bpmPattern);
        if (match.Success)
        {
            return int.Parse(match.Value);
        }
        return 0;
    }

    // 곡 길이를 파일 이름에서 추출하는 함수 (정규식 사용)
    private int ExtractSongLength()
    {
        string lengthPattern = @"(\d+)(?=s)";  // 's' 앞에 있는 숫자를 추출
        System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(song, lengthPattern);
        if (match.Success)
        {
            return int.Parse(match.Value);
        }
        return 0;
    }

    // 총 마디 수에 맞게 마디 스프라이트를 화면에 띄우는 함수
    private void SetMeasures(float totalMeasures)
    {
        // 기존에 생성된 마디 스프라이트들 초기화
        foreach (Transform child in beatContainer)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < totalMeasures; i++)
        {
            float screenHeight = scrollRect.viewport.rect.height;  // 스크롤 레크트 뷰포트의 높이
            float measureHeight = screenHeight / totalMeasures;  // 마디 한 개의 높이
            float lineHeight = screenHeight; // 마디 하나.

            // 레인 생성
            GameObject line = Instantiate(lines);
            line.transform.SetParent(parentMeasure.transform, false);  // 부모 오브젝트에 자식으로 추가

            // 레인 위치 조정
            RectTransform lineRect = line.GetComponent<RectTransform>();
            lineRect.anchoredPosition = new Vector2(0, i * 8.5f);  // 레인의 y 좌표 계산
            lineRect.sizeDelta = new Vector2(lines.GetComponent<RectTransform>().rect.width, lineHeight);  // 레인의 크기 조정

            // 마디 생성
            GameObject measure = Instantiate(measurePrefab);
            measure.transform.SetParent(parentMeasure.transform, false);  // 부모 오브젝트에 자식으로 추가

            // 마디 위치 조정
            RectTransform measureRect = measure.GetComponent<RectTransform>();
            measureRect.anchoredPosition = new Vector2(0.1f, -0.525f + i * 8.5f);  // 마디의 y 좌표 계산
            measureRect.sizeDelta = new Vector2(lines.GetComponent<RectTransform>().rect.width, lineHeight);  // 마디 크기 조정
        }
    }
}