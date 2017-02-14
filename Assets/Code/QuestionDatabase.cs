using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestionDatabase : MonoBehaviour
{
    public TextAsset questionsJSON;

    string questionsString;
    public List<Question> allQuestions = new List<Question>();

    void Start()
    {
        questionsString = questionsJSON.text;
        List<string> questions = questionsString.Split('}').ToList<string>();
        for (int i = 0; i < questions.Count-1; i++)
        {
            questions[i] += "}";
            allQuestions.Add(JsonUtility.FromJson<Question>(questions[i]));
        }
    }
}
