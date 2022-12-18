using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsUpdater : MonoBehaviour
{
    [SerializeField] public GameObject prefab;
    [SerializeField] public RectTransform content;

    private List<GameObject> addedPrefabs;

    private void Start()
    {
        addedPrefabs = new List<GameObject>();
    }

    public void AddResult(string result)
    {
        ShowPanel();
        var addedPrefab = Instantiate(prefab);
        
        
        addedPrefab.GetComponent<TextChanger>().ChangeText(result);
        addedPrefab.transform.SetParent(content,false);
        
        addedPrefabs.Add(addedPrefab);
    }

    public void RemoveResult(string text)
    {
        for (int i = 0; i < addedPrefabs.Count; i++)
        {
            if (addedPrefabs[i].GetComponent<TextChanger>().GetText() == text)
            {
                Destroy(addedPrefabs[i].gameObject);
                addedPrefabs.Remove(addedPrefabs[i]);
            }
        }

        if (addedPrefabs.Count <= 0)
        {
            HidePanel();
        }
    }
    
    public void HidePanel()
    {
        GetComponent<Image>().enabled = false;
    }

    public void ShowPanel()
    {
        GetComponent<Image>().enabled = true;
    }
}
