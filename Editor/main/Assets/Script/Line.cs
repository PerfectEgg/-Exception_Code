using UnityEngine;
using UnityEngine.UI;

public class CreateLanes : MonoBehaviour
{
    public Image backgroundImage; // 배경 이미지
    public int numberOfLanes = 4;  // 레인 수
    public float laneWidth = 100f; // 각 레인의 너비

    void Start()
    {
        if (backgroundImage != null)
        {
            // 배경 이미지의 크기와 비율에 맞게 레인 배치
            RectTransform bgRectTransform = backgroundImage.GetComponent<RectTransform>();

            // 레인 생성
            for (int i = 0; i < numberOfLanes; i++)
            {
                GameObject lane = new GameObject("Lane" + i);
                lane.transform.SetParent(backgroundImage.transform);

                // 레인 이미지 추가
                Image laneImage = lane.AddComponent<Image>();
                laneImage.color = Color.black; // 예시로 검정색 레인

                // RectTransform으로 위치와 크기 설정
                RectTransform laneRect = lane.GetComponent<RectTransform>();
                laneRect.sizeDelta = new Vector2(laneWidth, bgRectTransform.rect.height); // 레인 너비와 높이 설정
                laneRect.localPosition = new Vector3((i - (numberOfLanes - 1) / 2f) * laneWidth, 0, 0); // 중앙 정렬
            }
        }
    }
}