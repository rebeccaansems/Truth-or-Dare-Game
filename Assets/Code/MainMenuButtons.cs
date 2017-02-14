using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{

    public Canvas agePanel, naughtyPanel, groupTypePanel;

    bool isKids, isTeens, isAdults, isCouples, isNaughty;

    private void Start()
    {
        isKids = false;
        isTeens = false;
        isAdults = false;
        isCouples = false;
        isNaughty = false;

        agePanel.enabled = true;
        naughtyPanel.enabled = false;
        groupTypePanel.enabled = false;
    }

    public void isKidsButton()
    {
        isKids = true;
        isTeens = false;
        isAdults = false;
        isCouples = false;
        isNaughty = false;

        agePanel.enabled = false;
    }

    public void isTeensButton()
    {
        isKids = false;
        isTeens = true;
        isAdults = false;

        agePanel.enabled = false;
        naughtyPanel.enabled = true;
    }

    public void isAdultsButton()
    {
        isKids = false;
        isTeens = false;
        isAdults = true;

        agePanel.enabled = false;
        naughtyPanel.enabled = true;
    }

    public void isNaugtyButton(bool naughty)
    {
        isNaughty = naughty;

        naughtyPanel.enabled = false;
        groupTypePanel.enabled = true;
    }

    public void isCouplesButton(bool couples)
    {
        isCouples = couples;

        groupTypePanel.enabled = false;
    }
}
