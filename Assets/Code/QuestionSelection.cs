using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionSelection : MonoBehaviour
{
    public static bool isKids, isTeens, isAdults, isCouples, isNaughty;
    public Text chosenStatement;
    public UITransistion truthDareTrans;

    static int lastTruthIndex = 0, lastDareIndex = 0;
    
    public void truthSelected(bool withTransTime)
    {
        if (withTransTime)
        {
            truthDareTrans.TransOutQuestion();
        }
        StartCoroutine(truthQuestionSelected(withTransTime));
    }

    IEnumerator truthQuestionSelected(bool withTransTime)
    {
        if (withTransTime)
        {
            yield return new WaitForSeconds(0.8f);
        }

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
                break;
            }

            if (lastTruthIndex >= currentQuestionList.Count)
            {
                lastTruthIndex = 0;
            }
        }

        if (withTransTime)
        {
            truthDareTrans.TransInQuestion();
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
            truthSelected(true);
        }
        else
        {
            dareSelected();
        }

    }
}
