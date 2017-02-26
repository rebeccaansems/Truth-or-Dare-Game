using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableEnableAllButtons : MonoBehaviour
{

    public bool buttonsAreEnabled;

    Color[] colors;
    Button[] buttons;

    private void Start()
    {
        buttons = this.GetComponentsInChildren<Button>();
    }

    private void Update()
    {
        if (buttonsAreEnabled != buttons[0].interactable)
        {
            if (buttonsAreEnabled)
            {
                EnableAllButtons();
            }
            else
            {
                DisableAllButtons();
            }
        }
    }

    public void EnableAllButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void DisableAllButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }
}
