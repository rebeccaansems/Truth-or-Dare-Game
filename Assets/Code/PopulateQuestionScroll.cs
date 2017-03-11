using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateQuestionScroll : MonoBehaviour
{
    public GameObject scrollRect;
    public GameObject truthDareEditorStatement;
    public QuestionDatabase questionDatabase;

    PopulateEditorQuestion question;

    public void LoadQuestions()
    {
        for (int i = 0; i < QuestionDatabase.customQuestions.Count; i++)
        {
            GameObject newQuestion = Instantiate(truthDareEditorStatement, this.transform);
            newQuestion.transform.parent = this.transform;
            newQuestion.transform.localScale = new Vector3(1, 1, 1);
            question = newQuestion.GetComponent<PopulateEditorQuestion>();

            question.statementText.text = QuestionDatabase.customQuestions[i].Statement;

            question.isAdults.isOn = QuestionDatabase.customQuestions[i].isAdults;
            question.isTeens.isOn = QuestionDatabase.customQuestions[i].isTeens;
            question.isKids.isOn = QuestionDatabase.customQuestions[i].isKids;
            question.isNaughty.isOn = QuestionDatabase.customQuestions[i].isNaughty;
            question.isDare.isOn = QuestionDatabase.customQuestions[i].isDare;
        }
    }

    public void AddQuestion()
    {
        GameObject newQuestion = Instantiate(truthDareEditorStatement, this.transform);
        newQuestion.transform.parent = this.transform;
        newQuestion.transform.localScale = new Vector3(1, 1, 1);
        newQuestion.transform.SetAsFirstSibling();
    }

    public void SaveQuestions()
    {
        QuestionDatabase.customQuestions.Clear();
        foreach (Transform question in this.transform)
        {
            PopulateEditorQuestion currQuestion = question.GetComponent<PopulateEditorQuestion>();
            if (currQuestion.statementText.text != null && currQuestion.statementText.text != "" && currQuestion.statementText.text != " ")
            {
                bool questionIncluded = false;
                for (int i = 0; i < QuestionDatabase.customQuestions.Count; i++)
                {
                    if (QuestionDatabase.customQuestions[i].Statement.Equals(currQuestion.statementText.text))
                    {
                        questionIncluded = true;
                    }
                }

                if (!questionIncluded)
                {
                    QuestionDatabase.customQuestions.Add(new Question()
                    {
                        Statement = currQuestion.statementText.text,
                        isKids = currQuestion.isKids.isOn,
                        isTeens = currQuestion.isTeens.isOn,
                        isAdults = currQuestion.isAdults.isOn,
                        isDare = currQuestion.isDare.isOn,
                        isNaughty = currQuestion.isNaughty.isOn
                    });

                }
            }

            Destroy(question.gameObject);
        }
    }
}
