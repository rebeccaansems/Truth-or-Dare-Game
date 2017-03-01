using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionSelection : MonoBehaviour
{
    public static bool isKids, isTeens, isAdults, isCouples, isNaughty;
    public Text chosenStatement;
    public UITransistion truthDareTrans;
    public Outline outline;

    static int lastTruthIndex = 0, lastDareIndex = 0;

    Color dareColor = new Color32(204, 51, 63, 255), truthColor = new Color32(237, 201, 81, 255);
    
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
            yield return new WaitForSeconds(0.5f);
        }

        Question questionChosen;
        List<Question> currentQuestionList;
        outline.effectColor = truthColor;

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

            if (questionChosen.isDare == false && (questionChosen.isNaughty == isNaughty || isNaughty))
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

    public void dareSelected(bool withTransTime)
    {
        if (withTransTime)
        {
            truthDareTrans.TransOutQuestion();
        }
        StartCoroutine(dareQuestionSelected(withTransTime));
    }

    IEnumerator dareQuestionSelected(bool withTransTime)
    {
        if (withTransTime)
        {
            yield return new WaitForSeconds(0.5f);
        }

        Question questionChosen;
        List<Question> currentQuestionList;
        outline.effectColor = dareColor;

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

            if (questionChosen.isDare == true && (questionChosen.isNaughty == isNaughty || isNaughty))
            {
                chosenStatement.text = questionChosen.Statement;
                break;
            }

            if (lastDareIndex >= currentQuestionList.Count)
            {
                lastDareIndex = 0;
            }
        }

        if (withTransTime)
        {
            truthDareTrans.TransInQuestion();
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
            dareSelected(true);
        }

    }
}
