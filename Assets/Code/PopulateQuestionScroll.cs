using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateQuestionScroll : MonoBehaviour
{
    public GameObject scrollRect;
    public GameObject truthDareEditorStatement;

    PopulateEditorQuestion question;

    void OnEnable()
    {
        for(int i=0; i<QuestionDatabase.customQuestions.Count; i++)
        {
            GameObject newQuestion = Instantiate(truthDareEditorStatement, scrollRect.transform);
            question = newQuestion.GetComponent<PopulateEditorQuestion>();

            question.statementText.text = QuestionDatabase.customQuestions[i].Statement;
            question.isAdults.isOn = QuestionDatabase.customQuestions[i].Adults;
            question.isTeens.isOn = QuestionDatabase.customQuestions[i].Teens;
            question.isKids.isOn = QuestionDatabase.customQuestions[i].Kids;
            question.isNice.isOn = !QuestionDatabase.customQuestions[i].Naughty;
            question.isNaughty.isOn = QuestionDatabase.customQuestions[i].Naughty;
            question.isTruthOrDare.text = QuestionDatabase.customQuestions[i].isDare.ToString();

        }
    }
}
