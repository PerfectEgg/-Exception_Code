using UnityEngine;

public class Note : MonoBehaviour
{
    public GameManager gameManager; // GameManager ����

    public int lane;        // ���� ��ȣ (1, 2, 3, 4)
    public float timing;    // ��Ʈ�� �������� Ÿ�̹� (�� ����)
    public bool isHit;      // ��Ʈ�� �����Ǿ����� ����
    public KeyCode hitKey;  // �ش� ��Ʈ�� ó���ϴ� Ű
    public float speed = 5f; // ��Ʈ �������� �ӵ�
    public Sprite noteSprite; // ��Ʈ�� ��������Ʈ

    private SpriteRenderer spriteRenderer; // SpriteRenderer ������Ʈ

    void Start()
    {
        // SpriteRenderer ������Ʈ ���
        spriteRenderer = GetComponent<SpriteRenderer>();

        // ��Ʈ�� ��������Ʈ ����
        if (noteSprite != null)
        {
            spriteRenderer.sprite = noteSprite;
        }
    }

    public virtual void Update()
    {
        // Ÿ�ֿ̹� ���缭 ��Ʈ ������
        if (timing <= Time.time)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            // ȭ�� ������ ������ ��Ʈ ����
            if (transform.position.y < -6f)
            {
                gameManager.RemoveNoteFromList(this); // GameManager���� ����
                Destroy(gameObject);
            }
        }
    }

    public virtual void CheckHit(float currentTime, NoteJudgement judgement)
    {
        if (Input.GetKeyDown(hitKey))  // ��Ʈ�� �ش��ϴ� Ű�� ������ ��
        {
            judgement.ApplyJudgement(this, currentTime);  // ���� ����
        }
    }

}


public class RedNote : Note
{
    public int[] overlappingLanes;

    public override void Update()
    {
        // Ÿ�ֿ̹� ���缭 ���� ��Ʈ�� ���������� ó��
        if (timing <= Time.time)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            // ȭ�� ������ ������ ���� ��Ʈ ����
            if (transform.position.y < -6f)
            {
                Destroy(gameObject);
            }
        }
    }


    public override void CheckHit(float currentTime, NoteJudgement judgement)
    {
        if (Input.GetKeyDown(hitKey))  // ������ RedNote�� �ش��ϴ� Ű�� ������ ��
        {
            judgement.ApplyJudgement(this, currentTime);
        }
    }
}
