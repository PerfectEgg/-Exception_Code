using UnityEngine;
using System.Collections.Generic;

public class NoteJudgement
{
    // 판정 기준을 저장하는 Dictionary
    private Dictionary<string, float> judgementRanges = new Dictionary<string, float> {
        { "Success", 0.042f },    // Success(100%, ±42ms)
        { "ValidAlmost", 0.063f }, // Valid [Almost] (90%, ±63ms)
        { "ValidOk", 0.084f },     // Valid [Ok] (50%, ±84ms)
        { "ValidWeak", 0.105f }    // Valid [Weak] (10%, ±105ms)
    };

    // 타이밍 차이에 따른 판정 결과를 반환하는 메서드
    public string GetJudgement(float timingDifference)
    {
        foreach (var judgement in judgementRanges)
        {
            if (timingDifference <= judgement.Value)
            {
                int percentage = (int)(100 * (1 - (timingDifference / judgement.Value)));
                return $"{judgement.Key} ({percentage}%)";
            }
        }

        return "Error (0%)";  // 범위 밖이면 Error 판정
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
        }

        Debug.Log(judgementResult);
    }
}
