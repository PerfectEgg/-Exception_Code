using UnityEngine;
using UnityEngine.UI;

public class CreateLanes : MonoBehaviour
{
    public Image backgroundImage; // ��� �̹���
    public int numberOfLanes = 4;  // ���� ��
    public float laneWidth = 100f; // �� ������ �ʺ�

    void Start()
    {
        if (backgroundImage != null)
        {
            // ��� �̹����� ũ��� ������ �°� ���� ��ġ
            RectTransform bgRectTransform = backgroundImage.GetComponent<RectTransform>();

            // ���� ����
            for (int i = 0; i < numberOfLanes; i++)
            {
                GameObject lane = new GameObject("Lane" + i);
                lane.transform.SetParent(backgroundImage.transform);

                // ���� �̹��� �߰�
                Image laneImage = lane.AddComponent<Image>();
                laneImage.color = Color.black; // ���÷� ������ ����

                // RectTransform���� ��ġ�� ũ�� ����
                RectTransform laneRect = lane.GetComponent<RectTransform>();
                laneRect.sizeDelta = new Vector2(laneWidth, bgRectTransform.rect.height); // ���� �ʺ�� ���� ����
                laneRect.localPosition = new Vector3((i - (numberOfLanes - 1) / 2f) * laneWidth, 0, 0); // �߾� ����
            }
        }
    }
}