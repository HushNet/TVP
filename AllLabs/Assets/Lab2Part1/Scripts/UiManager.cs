using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class UiManager : MonoBehaviour
{
    [SerializeField] public List<string> preparedResults;
    [SerializeField] public SearchTrigger searchTrigger;
    [SerializeField] public ResultsUpdater resultsUpdater;

    private List<string> addedResults;

    [SerializeField] public bool allowRegisterCheck;

    public void Start()
    {
        addedResults = new List<string>();

        if (!allowRegisterCheck)
        {
            for (int i = 0; i < preparedResults.Count; i++)
            {
                preparedResults[i] = preparedResults[i].ToLower();
            }
        }
        
    }

    public void ShowResultsByText(string text)
    {
        if(!allowRegisterCheck)
            text = text.ToLower();
        
        for (int i = 0; i < addedResults.Count; i++)
        {
            if (!addedResults[i].StartsWith(text))
            {
                resultsUpdater.RemoveResult(addedResults[i]);
                addedResults.Remove(addedResults[i]);
                i--;
            }
        }
        
        for (int i = 0; i < preparedResults.Count; i++)
        {
            if (preparedResults[i].StartsWith(text) && !addedResults.Contains(preparedResults[i]))
            {
                resultsUpdater.AddResult(preparedResults[i]);
                addedResults.Add(preparedResults[i]);
            }
        }
    }


}
