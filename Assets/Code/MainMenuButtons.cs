using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{

    public Canvas agePanel, naughtyPanel, truthDarePanel;
    public Text truthDareStatement;
    public QuestionSelection qs;

    private void Start()
    {
        QuestionSelection.isKids = false;
        QuestionSelection.isTeens = false;
        QuestionSelection.isAdults = false;
        QuestionSelection.isCouples = false;
        QuestionSelection.isNaughty = false;

        agePanel.enabled = true;
        naughtyPanel.enabled = false;
        truthDarePanel.enabled = false;
    }

    public void isKidsButton()
    {
        QuestionSelection.isKids = true;
        QuestionSelection.isTeens = false;
        QuestionSelection.isAdults = false;
        QuestionSelection.isCouples = false;
        QuestionSelection.isNaughty = false;

        agePanel.enabled = false;
        truthDarePanel.enabled = true;
        qs.truthSelected();
    }

    public void isTeensButton()
    {
        QuestionSelection.isKids = false;
        QuestionSelection.isTeens = true;
        QuestionSelection.isAdults = false;

        agePanel.enabled = false;
        naughtyPanel.enabled = true;
    }

    public void isAdultsButton()
    {
        QuestionSelection.isKids = false;
        QuestionSelection.isTeens = false;
        QuestionSelection.isAdults = true;

        agePanel.enabled = false;
        naughtyPanel.enabled = true;
    }

    public void isNaugtyButton(bool naughty)
    {
        QuestionSelection.isNaughty = naughty;

        naughtyPanel.enabled = false;
        truthDarePanel.enabled = true;

        qs.truthSelected();
    }
}
