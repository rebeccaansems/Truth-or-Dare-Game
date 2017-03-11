using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateEditorQuestion : MonoBehaviour
{
    public InputField statementText;
    public Toggle isKids, isTeens, isAdults, isDare, isNaughty;
    public Button removeQuestion, editQuestion, submitQuestion;

    private void Update()
    {
        if(!isKids.isOn && !isTeens.isOn && !isAdults.isOn)
        {
            isAdults.isOn = true;
        }
    }

    private void Start()
    {
        submitQuestion.gameObject.SetActive(false);
        statementText.interactable = false;
        isKids.interactable = false;
        isTeens.interactable = false;
        isAdults.interactable = false;
        isDare.interactable = false;
        isNaughty.interactable = false;
    }

    public void EditQuestion()
    {
        editQuestion.gameObject.SetActive(false);

        submitQuestion.gameObject.SetActive(true);
        statementText.interactable = true;
        isKids.interactable = true;
        isTeens.interactable = true;
        isAdults.interactable = true;
        isDare.interactable = true;
        isNaughty.interactable = true;
    }

    public void SubmitQuestion()
    {
        editQuestion.gameObject.SetActive(true);

        submitQuestion.gameObject.SetActive(false);
        statementText.interactable = false;
        isKids.interactable = false;
        isTeens.interactable = false;
        isAdults.interactable = false;
        isDare.interactable = false;
        isNaughty.interactable = false;
    }

    public void DeleteQuestion()
    {
        Destroy(this.gameObject);
    }
}
