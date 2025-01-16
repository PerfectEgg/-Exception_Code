using UnityEngine;

public class Note : MonoBehaviour
{
    public GameManager gameManager; // GameManager 참조

    public int lane;        // 레인 번호 (1, 2, 3, 4)
    public float timing;    // 노트가 떨어지는 타이밍 (초 단위)
    public bool isHit;      // 노트가 판정되었는지 여부
    public KeyCode hitKey;  // 해당 노트를 처리하는 키
    public float speed = 5f; // 노트 떨어지는 속도
    public Sprite noteSprite; // 노트의 스프라이트

    private SpriteRenderer spriteRenderer; // SpriteRenderer 컴포넌트

    void Start()
    {
        // SpriteRenderer 컴포넌트 얻기
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 노트에 스프라이트 설정
        if (noteSprite != null)
        {
            spriteRenderer.sprite = noteSprite;
        }
    }

    public virtual void Update()
    {
        // 타이밍에 맞춰서 노트 떨어짐
        if (timing <= Time.time)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            // 화면 밖으로 나가면 노트 삭제
            if (transform.position.y < -6f)
            {
                gameManager.RemoveNoteFromList(this); // GameManager에서 제거
                Destroy(gameObject);
            }
        }
    }

    public virtual void CheckHit(float currentTime, NoteJudgement judgement)
    {
        if (Input.GetKeyDown(hitKey))  // 노트에 해당하는 키를 눌렀을 때
        {
            judgement.ApplyJudgement(this, currentTime);  // 판정 수행
        }
    }

}


public class RedNote : Note
{
    public int[] overlappingLanes;

    public override void Update()
    {
        // 타이밍에 맞춰서 레드 노트는 떨어지도록 처리
        if (timing <= Time.time)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            // 화면 밖으로 나가면 레드 노트 삭제
            if (transform.position.y < -6f)
            {
                Destroy(gameObject);
            }
        }
    }


    public override void CheckHit(float currentTime, NoteJudgement judgement)
    {
        if (Input.GetKeyDown(hitKey))  // 유저가 RedNote에 해당하는 키를 눌렀을 때
        {
            judgement.ApplyJudgement(this, currentTime);
        }
    }
}
