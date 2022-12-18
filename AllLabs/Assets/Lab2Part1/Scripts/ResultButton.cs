using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultButton : MonoBehaviour
{
    public void SendTextInfo()
    {
        var gObj = GameObject.FindGameObjectWithTag("InputField");
        var text = GetComponentInChildren<TextMeshProUGUI>().text;
        

        gObj.GetComponent<InputTextChanger>().ChangeText(text);
    }
}
