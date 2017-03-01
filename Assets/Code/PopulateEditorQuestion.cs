using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateEditorQuestion : MonoBehaviour
{
    public InputField statementText;
    public Toggle isKids, isTeens, isAdults;
    public Text isTruthOrDare, isNaughty;
    public Button removeQuestion;

    public void TruthOrDareButton()
    {
        if (isTruthOrDare.text.Equals("Truth"))
        {
            isTruthOrDare.text = "Dare";
        }
        else
        {
            isTruthOrDare.text = "Truth";
        }
    }

    public void NaughtyOrNiceButton()
    {
        if (isNaughty.text.Equals("Naughty"))
        {
            isNaughty.text = "Nice";
        }
        else
        {
            isNaughty.text = "Naughty";
        }
    }

    public void DeleteQuestion()
    {
        Destroy(this.gameObject);
    }
}
