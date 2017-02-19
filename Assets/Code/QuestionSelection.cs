using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionSelection : MonoBehaviour
{
    public static bool isKids, isTeens, isAdults, isCouples, isNaughty;
    public Text chosenStatement;

    static int lastTruthIndex = 0, lastDareIndex = 0;

    public void truthSelected()
    {
        Question questionChosen;
        List<Question> currentQuestionList;

        if (isAdults)
        {
            currentQuestionList = QuestionDatabase.adultsQuestions;
        }
        else if (isTeens)
        {
            currentQuestionList = QuestionDatabase.teensQuestions;
        }
        else
        {
            currentQuestionList = QuestionDatabase.kidsQuestions;
        }

        for (int i = 0; i < currentQuestionList.Count; i++)
        {
            questionChosen = currentQuestionList[lastTruthIndex];
            lastTruthIndex++;

            if (questionChosen.isDare == false && (questionChosen.Naughty == isNaughty || isNaughty))
            {
                chosenStatement.text = questionChosen.Statement;
                return;
            }

            if (lastTruthIndex >= currentQuestionList.Count)
            {
                lastTruthIndex = 0;
            }
        }
    }

    public void dareSelected()
    {
        Question questionChosen;
        List<Question> currentQuestionList;

        if (isAdults)
        {
            currentQuestionList = QuestionDatabase.adultsQuestions;
        }
        else if (isTeens)
        {
            currentQuestionList = QuestionDatabase.teensQuestions;
        }
        else
        {
            currentQuestionList = QuestionDatabase.kidsQuestions;
        }

        for (int i = 0; i < currentQuestionList.Count; i++)
        {
            questionChosen = currentQuestionList[lastDareIndex];
            lastDareIndex++;

            if (questionChosen.isDare == true && (questionChosen.Naughty == isNaughty || isNaughty))
            {
                chosenStatement.text = questionChosen.Statement;
                return;
            }

            if (lastDareIndex >= currentQuestionList.Count)
            {
                lastDareIndex = 0;
            }
        }
    }

    public void randomSelected()
    {
        if (Random.Range(0, 2) == 0)
        {
            truthSelected();
        }
        else
        {
            dareSelected();
        }

    }
}
