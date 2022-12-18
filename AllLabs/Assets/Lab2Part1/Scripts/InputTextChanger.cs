using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputTextChanger : MonoBehaviour
{
    public void ChangeText(string text)
    {
        GetComponentInChildren<TMP_InputField>().text = text;
    }

    public string GetText()
    {
        return GetComponentInChildren<TMP_InputField>().text;
    }
}
