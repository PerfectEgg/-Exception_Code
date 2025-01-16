using UnityEngine;
using System.Collections.Generic;

public class NoteJudgement
{
    public GameManager gameManager; // GameManager 참조

    // 판정 기준을 저장하는 Dictionary
    private Dictionary<string, float> judgementRanges = new Dictionary<string, float> {
        { "Success", 0.042f },    // Success(100%, ±42ms)
        { "Valid [Almost]", 0.063f }, // Valid [Almost] (90%, ±63ms)
        { "Valid [Ok]", 0.084f },     // Valid [Ok] (50%, ±84ms)
        { "Valid [Weak]", 0.105f }    // Valid [Weak] (10%, ±105ms)
    };

    // 타이밍 차이에 따른 판정 결과를 반환하는 메서드
    public string GetJudgement(float timingDifference)
    {
        foreach (var judgement in judgementRanges)
        {
            if (timingDifference <= judgement.Value)
            {
                int percentage = (int)(100 * (1 - (timingDifference / judgement.Value)));
                return $"{judgement.Key})";
            }
        }

        return "Error";  // 범위 밖이면 Error 판정
    }

    // 타이밍 차이에 따라 판정을 적용하는 메서드
    public void ApplyJudgement(Note note, float currentTime)
    {
        float timingDifference = Mathf.Abs(note.timing - currentTime);
        string judgementResult = GetJudgement(timingDifference);

        if (judgementResult.StartsWith("Error"))
        {
            note.isHit = false;
        }
        else
        {
            note.isHit = true;

            // 점수 부여 로직 추가
            int score = judgementResult.Contains("Success") ? 100 :
                        judgementResult.Contains("Almost") ? 80 :
                        judgementResult.Contains("Ok") ? 50 : 20;

            gameManager.AddScore(score);

        }

        Debug.Log(judgementResult);
    }
}
