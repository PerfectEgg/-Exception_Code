using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    public Scrollbar verticalScrollbar; // 스크롤바 (Vertical)
    public RectTransform parentMeasure; // 레인과 마디가 들어있는 부모 오브젝트
    public Transform measureContainer; // 마디가 들어갈 컨테이너
    public Transform lineContainer; // 레인이 들어갈 컨테이너

    public void Start()
    {
        // 초기 상태에서는 parentMeasure가 비활성화되어 있을 수 있음
        parentMeasure.gameObject.SetActive(false);

        // 스크롤 이벤트를 처리할 리스너 추가
        verticalScrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
    }

    // 곡을 로드한 후 호출
    public void LoadSong()
    {
        // 곡 로딩 후 parentMeasure 활성화
        parentMeasure.gameObject.SetActive(true);
    }

    // 스크롤 이벤트 발생 시 (스크롤바 값이 변경될 때 호출)
    public void OnScrollbarValueChanged(float value)
    {
        // ScrollRect의 세로 길이
        float scrollHeight = verticalScrollbar.GetComponentInParent<ScrollRect>().viewport.rect.height;

        // parentMeasure의 전체 세로 길이 (동적으로 계산)
        float totalHeight = CalculateParentMeasureHeight();

        // parentMeasure의 Y 좌표를 0에서 totalHeight 사이로 설정
        // value가 0일 때 parentMeasure는 맨 위에, 1일 때 맨 아래에 위치해야 합니다.
        float targetYPosition = (1 - value) * (totalHeight - scrollHeight);

        // parentMeasure의 Y 좌표를 변경
        parentMeasure.anchoredPosition = new Vector2(0, targetYPosition);
    }

    // parentMeasure의 총합 높이를 계산하는 함수
    private float CalculateParentMeasureHeight()
    {
        // 총합 높이 계산 로직
        // 예를 들어, `measureContainer`와 `lineContainer`의 높이를 합산할 수 있습니다.
        float totalHeight = 0;

        // 예시: measureContainer와 lineContainer의 높이를 합산
        totalHeight += measureContainer.GetComponent<RectTransform>().rect.height;
        totalHeight += lineContainer.GetComponent<RectTransform>().rect.height;

        // 실제 로직에 맞게 총합 높이를 계산
        return totalHeight;
    }

    // parentMeasure의 Y 위치가 변경될 때마다 Scrollbar의 value 자동 변경
    public void UpdateScrollbarValue()
    {
        // parentMeasure의 현재 위치를 계산
        float targetYPosition = parentMeasure.anchoredPosition.y;

        // ScrollRect의 세로 길이
        float scrollHeight = verticalScrollbar.GetComponentInParent<ScrollRect>().viewport.rect.height;

        // parentMeasure의 전체 세로 길이
        float totalHeight = CalculateParentMeasureHeight();

        Debug.Log("targetYPosition: " + targetYPosition);
        Debug.Log("scrollHeight: " + scrollHeight);
        Debug.Log("totalHeight: " + totalHeight);

        // Scrollbar의 value를 업데이트
        // (parentMeasure의 위치를 스크롤 가능한 영역의 비율로 변환)
        float value = (targetYPosition / (totalHeight - (200 - scrollHeight)));
        verticalScrollbar.value = Mathf.Clamp01(value);

        Debug.Log("verticalScrollbar: " + value);
    }
}
