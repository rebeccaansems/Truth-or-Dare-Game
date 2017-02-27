using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUiButtons : MonoBehaviour
{

    public GameObject optionsCanvas;

    private void Start()
    {
        optionsCanvas.SetActive(false);
    }

    public void PauseButtonPressed(bool pausePressed)
    {
        optionsCanvas.SetActive(pausePressed);
    }

    
}
