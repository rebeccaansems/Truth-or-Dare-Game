using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionButtons : MonoBehaviour
{
    public Canvas agePanel, naughtyPanel, truthDarePanel;
    public Text truthDareStatement;
    public QuestionSelection qs;
    public UITransistion playGame, ageTrans, naughtyTrans, truthDareTrans;

    public void StartGame()
    {
        playGame.TransOut();

        QuestionSelection.isKids = false;
        QuestionSelection.isTeens = false;
        QuestionSelection.isAdults = false;
        QuestionSelection.isCouples = false;
        QuestionSelection.isNaughty = false;

        ageTrans.TransIn();
    }

    public void isKidsButton()
    {
        ageTrans.TransOut();

        QuestionSelection.isKids = true;
        QuestionSelection.isTeens = false;
        QuestionSelection.isAdults = false;
        QuestionSelection.isCouples = false;
        QuestionSelection.isNaughty = false;

        truthDareTrans.TransIn();

        qs.truthSelected(false);
    }

    public void isTeensButton()
    {
        ageTrans.TransOut();

        QuestionSelection.isKids = false;
        QuestionSelection.isTeens = true;
        QuestionSelection.isAdults = false;

        naughtyTrans.TransIn();
    }

    public void isAdultsButton()
    {
        ageTrans.TransOut();

        QuestionSelection.isKids = false;
        QuestionSelection.isTeens = false;
        QuestionSelection.isAdults = true;

        naughtyTrans.TransIn();
    }

    public void isNaugtyButton(bool naughty)
    {
        naughtyTrans.TransOut();

        QuestionSelection.isNaughty = naughty;

        truthDareTrans.TransIn();

        qs.truthSelected(false);
    }
}
