using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SearchTrigger : MonoBehaviour
{
    [SerializeField] public UiManager uiManager;

    [SerializeField] public TMP_InputField tmpIF;


    public void ShowResults()
    {
        var text = tmpIF.text;
        if (text == "" || text == " ")
        {
            uiManager.ShowResultsByText("]]]]]]]]]]]]]]]]]]]]]");
        }
        else
        {
            uiManager.ShowResultsByText(text);
        }
    }
}
