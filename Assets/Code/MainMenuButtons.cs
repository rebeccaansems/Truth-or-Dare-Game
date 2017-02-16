using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{

    public Canvas agePanel, naughtyPanel, groupTypePanel, truthDarePanel;
    public Text truthDareStatement;

    private void Start()
    {
        QuestionSelection.isKids = false;
        QuestionSelection.isTeens = false;
        QuestionSelection.isAdults = false;
        QuestionSelection.isCouples = false;
        QuestionSelection.isNaughty = false;

        agePanel.enabled = true;
        naughtyPanel.enabled = false;
        groupTypePanel.enabled = false;
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
        groupTypePanel.enabled = true;
    }

    public void isCouplesButton(bool couples)
    {
        QuestionSelection.isCouples = couples;

        groupTypePanel.enabled = false;
        truthDarePanel.enabled = true;
    }
}
