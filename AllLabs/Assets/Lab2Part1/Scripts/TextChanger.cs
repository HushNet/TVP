using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
    public void ChangeText(string text)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = text;
    }

    public string GetText()
    {
        return GetComponentInChildren<TextMeshProUGUI>().text;
    }
}
