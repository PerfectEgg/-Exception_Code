using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public List<Note> notes; // 현재 화면에 있는 노트들
    private NoteJudgement judgement; // 판정 클래스
    private int score; // 인게임의 판정

    void Start()
    {
        score = 0;
        judgement = new NoteJudgement();  // 판정 클래스 초기화
        notes = new List<Note>();  // 노트 리스트 초기화
    }

    void Update()
    {
        // 화면에 있는 노트들을 업데이트하면서 판정을 체크
        foreach (Note note in notes)
        {
            note.CheckHit(Time.time, judgement);  // 노트가 떨어지면서 판정 체크
        }
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public void AddNoteToList(Note note)
    {
        notes.Add(note);  // 노트를 추가
    }

    public void RemoveNoteFromList(Note note)
    {
        notes.Remove(note);  // 노트를 제거
    }
}
