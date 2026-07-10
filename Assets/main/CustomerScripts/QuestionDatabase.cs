using UnityEngine;

public class QuestionDatabase : MonoBehaviour
{
    public Question[] questions;

    public Question GetRandomQuestion()
    {
        int r = Random.Range(0, questions.Length);
        return questions[r];
    }
}
