using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateQuestionScroll : MonoBehaviour
{
    public GameObject scrollRect;
    public GameObject truthDareEditorStatement;

    PopulateEditorQuestion question;

    public void LoadQuestions()
    {
        for (int i = 0; i < QuestionDatabase.customQuestions.Count; i++)
        {
            GameObject newQuestion = Instantiate(truthDareEditorStatement, scrollRect.transform);
            newQuestion.transform.localScale = new Vector3(1, 1, 1);
            question = newQuestion.GetComponent<PopulateEditorQuestion>();

            question.statementText.text = QuestionDatabase.customQuestions[i].Statement;
            question.isNaughty.text = QuestionDatabase.customQuestions[i].isNaughty ? "Naughty" : "Nice";
            question.isTruthOrDare.text = QuestionDatabase.customQuestions[i].isDare ? "Dare" : "Truth";

            question.isAdults.isOn = QuestionDatabase.customQuestions[i].isAdults;
            question.isTeens.isOn = QuestionDatabase.customQuestions[i].isTeens;
            question.isKids.isOn = QuestionDatabase.customQuestions[i].isKids;
        }
    }

    public void AddQuestion()
    {
        GameObject newQuestion = Instantiate(truthDareEditorStatement, scrollRect.transform);
        newQuestion.transform.localScale = new Vector3(1, 1, 1);
        newQuestion.transform.SetAsFirstSibling();
    }

    public void SaveQuestions()
    {
        QuestionDatabase.customQuestions.Clear();
        foreach (Transform question in scrollRect.transform)
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
                    bool isTruthOrDare = currQuestion.isTruthOrDare.text.Equals("Dare");
                    bool isNaughty = currQuestion.isNaughty.text.Equals("Naughty");

                    QuestionDatabase.customQuestions.Add(new Question()
                    {
                        Statement = currQuestion.statementText.text,
                        isDare = isTruthOrDare,
                        isKids = currQuestion.isKids,
                        isTeens = currQuestion.isTeens,
                        isNaughty = currQuestion.isNaughty
                    });

                }
            }

            Destroy(question.gameObject);
        }
    }
}
