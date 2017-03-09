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
    public static List<Question> customQuestions = new List<Question>();

    void Start()
    {
        questionsString = questionsJSON.text;
        List<string> questions = questionsString.Split('}').ToList<string>();
        for (int i = 0; i < questions.Count - 1; i++)
        {
            questions[i] += "}";
            Question question = JsonUtility.FromJson<Question>(questions[i]);

            if (question.isAdults)
            {
                adultsQuestions.Add(question);
            }

            if (question.isTeens)
            {
                teensQuestions.Add(question);
            }

            if (question.isKids)
            {
                kidsQuestions.Add(question);
            }
        }

        LoadCustomQuestions();

        kidsQuestions = Fisher_Yates_Shuffle(kidsQuestions);
        teensQuestions = Fisher_Yates_Shuffle(teensQuestions);
        adultsQuestions = Fisher_Yates_Shuffle(adultsQuestions);
    }
    
    void LoadCustomQuestions()
    {
        int i = 0;

        while (PlayerPrefs.HasKey("CustomQuestion_" + i + "_Statement"))
        {
            customQuestions.Add(new Question()
            {
                Statement = PlayerPrefs.GetString("CustomQuestion_" + i + "_Statement"),
                isDare = PlayerPrefs.GetInt("CustomQuestion_" + i + "_IsDare") == 0,
                isNaughty = PlayerPrefs.GetInt("CustomQuestion_" + i + "_IsNaughty") == 0,
                isKids = PlayerPrefs.GetInt("CustomQuestion_" + i + "_IsKids") == 0,
                isTeens = PlayerPrefs.GetInt("CustomQuestion_" + i + "_IsTeens") == 0,
                isAdults = PlayerPrefs.GetInt("CustomQuestion_" + i + "_IsAdults") == 0
            });

            if (customQuestions[i].isAdults)
            {
                adultsQuestions.Add(customQuestions[i]);
            }

            if (customQuestions[i].isTeens)
            {
                teensQuestions.Add(customQuestions[i]);
            }

            if (customQuestions[i].isKids)
            {
                kidsQuestions.Add(customQuestions[i]);
            }

            i++;
        }
    }

    public void ReloadQuestions()
    {
        kidsQuestions.Clear();
        teensQuestions.Clear();
        adultsQuestions.Clear();
        
        Start();
        LoadCustomQuestions();
    }

    List<Question> Fisher_Yates_Shuffle(List<Question> aList)
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

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
        for (int i = 0; i < customQuestions.Count; i++)
        {
            PlayerPrefs.SetString("CustomQuestion_" + i + "_Statement", customQuestions[i].Statement);

            PlayerPrefs.SetInt("CustomQuestion_" + i + "_IsDare", customQuestions[i].isDare ? 0 : 1);

            PlayerPrefs.SetInt("CustomQuestion_" + i + "_IsNaughty", customQuestions[i].isNaughty ? 0 : 1);
            PlayerPrefs.SetInt("CustomQuestion_" + i + "_IsKids", customQuestions[i].isKids ? 0 : 1);
            PlayerPrefs.SetInt("CustomQuestion_" + i + "_IsTeens", customQuestions[i].isTeens ? 0 : 1);
            PlayerPrefs.SetInt("CustomQuestion_" + i + "_IsAdults", customQuestions[i].isAdults ? 0 : 1);
        }
    }
}
