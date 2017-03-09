using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateEditorQuestion : MonoBehaviour
{
    public InputField statementText;
    public Toggle isKids, isTeens, isAdults, isDare, isNaughty;
    public Button removeQuestion;

    public void DeleteQuestion()
    {
        Destroy(this.gameObject);
    }
}
