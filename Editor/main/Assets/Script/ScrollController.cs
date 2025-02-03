using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    public Scrollbar verticalScrollbar; // ��ũ�ѹ� (Vertical)
    public RectTransform parentMeasure; // ���ΰ� ���� ����ִ� �θ� ������Ʈ
    public Transform measureContainer; // ���� �� �����̳�
    public Transform lineContainer; // ������ �� �����̳�

    public void Start()
    {
        // �ʱ� ���¿����� parentMeasure�� ��Ȱ��ȭ�Ǿ� ���� �� ����
        parentMeasure.gameObject.SetActive(false);

        // ��ũ�� �̺�Ʈ�� ó���� ������ �߰�
        verticalScrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
    }

    // ���� �ε��� �� ȣ��
    public void LoadSong()
    {
        // �� �ε� �� parentMeasure Ȱ��ȭ
        parentMeasure.gameObject.SetActive(true);
    }

    // ��ũ�� �̺�Ʈ �߻� �� (��ũ�ѹ� ���� ����� �� ȣ��)
    public void OnScrollbarValueChanged(float value)
    {
        // ScrollRect�� ���� ����
        float scrollHeight = verticalScrollbar.GetComponentInParent<ScrollRect>().viewport.rect.height;

        // parentMeasure�� ��ü ���� ���� (�������� ���)
        float totalHeight = CalculateParentMeasureHeight();

        // parentMeasure�� Y ��ǥ�� 0���� totalHeight ���̷� ����
        // value�� 0�� �� parentMeasure�� �� ����, 1�� �� �� �Ʒ��� ��ġ�ؾ� �մϴ�.
        float targetYPosition = (1 - value) * (totalHeight - scrollHeight);

        // parentMeasure�� Y ��ǥ�� ����
        parentMeasure.anchoredPosition = new Vector2(0, targetYPosition);
    }

    // parentMeasure�� ���� ���̸� ����ϴ� �Լ�
    private float CalculateParentMeasureHeight()
    {
        // ���� ���� ��� ����
        // ���� ���, `measureContainer`�� `lineContainer`�� ���̸� �ջ��� �� �ֽ��ϴ�.
        float totalHeight = 0;

        // ����: measureContainer�� lineContainer�� ���̸� �ջ�
        totalHeight += measureContainer.GetComponent<RectTransform>().rect.height;
        totalHeight += lineContainer.GetComponent<RectTransform>().rect.height;

        // ���� ������ �°� ���� ���̸� ���
        return totalHeight;
    }

    // parentMeasure�� Y ��ġ�� ����� ������ Scrollbar�� value �ڵ� ����
    public void UpdateScrollbarValue()
    {
        // parentMeasure�� ���� ��ġ�� ���
        float targetYPosition = parentMeasure.anchoredPosition.y;

        // ScrollRect�� ���� ����
        float scrollHeight = verticalScrollbar.GetComponentInParent<ScrollRect>().viewport.rect.height;

        // parentMeasure�� ��ü ���� ����
        float totalHeight = CalculateParentMeasureHeight();

        Debug.Log("targetYPosition: " + targetYPosition);
        Debug.Log("scrollHeight: " + scrollHeight);
        Debug.Log("totalHeight: " + totalHeight);

        // Scrollbar�� value�� ������Ʈ
        // (parentMeasure�� ��ġ�� ��ũ�� ������ ������ ������ ��ȯ)
        float value = (targetYPosition / (totalHeight - (200 - scrollHeight)));
        verticalScrollbar.value = Mathf.Clamp01(value);

        Debug.Log("verticalScrollbar: " + value);
    }
}
