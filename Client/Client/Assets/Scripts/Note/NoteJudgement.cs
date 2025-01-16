using UnityEngine;
using System.Collections.Generic;

public class NoteJudgement
{
    public GameManager gameManager; // GameManager ����

    // ���� ������ �����ϴ� Dictionary
    private Dictionary<string, float> judgementRanges = new Dictionary<string, float> {
        { "Success", 0.042f },    // Success(100%, ��42ms)
        { "Valid [Almost]", 0.063f }, // Valid [Almost] (90%, ��63ms)
        { "Valid [Ok]", 0.084f },     // Valid [Ok] (50%, ��84ms)
        { "Valid [Weak]", 0.105f }    // Valid [Weak] (10%, ��105ms)
    };

    // Ÿ�̹� ���̿� ���� ���� ����� ��ȯ�ϴ� �޼���
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

        return "Error";  // ���� ���̸� Error ����
    }

    // Ÿ�̹� ���̿� ���� ������ �����ϴ� �޼���
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

            // ���� �ο� ���� �߰�
            int score = judgementResult.Contains("Success") ? 100 :
                        judgementResult.Contains("Almost") ? 80 :
                        judgementResult.Contains("Ok") ? 50 : 20;

            gameManager.AddScore(score);

        }

        Debug.Log(judgementResult);
    }
}
