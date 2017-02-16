using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestionDatabase : MonoBehaviour
{
    public TextAsset questionsJSON;

    string questionsString;
    public static List<Question> kidsQuestions = new List<Question>();
    public static List<Question> teensQuestions = new List<Question>();
    public static List<Question> adultsQuestions = new List<Question>();

    void Start()
    {
        questionsString = questionsJSON.text;
        List<string> questions = questionsString.Split('}').ToList<string>();
        for (int i = 0; i < questions.Count-1; i++)
        {
            questions[i] += "}";
            Question question = JsonUtility.FromJson<Question>(questions[i]);

            if (question.Adults)
            {
                adultsQuestions.Add(question);
            }

            if (question.Teens)
            {
                teensQuestions.Add(question);
            }

            if (question.Kids)
            {
                kidsQuestions.Add(question);
            }
        }

        kidsQuestions = Fisher_Yates_Shuffle(kidsQuestions);
        teensQuestions = Fisher_Yates_Shuffle(teensQuestions);
        adultsQuestions = Fisher_Yates_Shuffle(adultsQuestions);
    }

    public static List<Question> Fisher_Yates_Shuffle(List<Question> aList)
    {
        System.Random _random = new System.Random();
        Question myGO;

        int n = aList.Count;
        for (int i = 0; i < n; i++)
        {
            int r = i + (int)(_random.NextDouble() * (n - i));
            myGO = aList[r];
            aList[r] = aList[i];
            aList[i] = myGO;
        }
        return aList;
    }
}
