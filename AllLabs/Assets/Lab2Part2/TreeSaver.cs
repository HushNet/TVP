using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using UnityEngine;

public class TreeSaver : MonoBehaviour
{
    [SerializeField] public List<string> objectNamesList;
    [SerializeField] public List<GameObject> objectsList;
    [SerializeField] public GameObject spawnPos;
    [SerializeField] public string fileName;
    [SerializeField] public List<GameObject> noSaveObj;

    private void Start()
    {
        objectNamesList = new List<string>();
        objectsList = new List<GameObject>();

        GetAllObjects();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveObjectNames(GetObjectNames());
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CreateObjects(LoadObjectNames());
        }
    }

    public List<GameObject> GetAllObjects()
    {
        objectsList.Clear();
        objectsList = FindObjectsOfType<GameObject>().ToList();

        for (int i = 0; i < objectsList.Count; i++)
        {
            if (objectsList[i].CompareTag("NoSave") || noSaveObj.Contains(objectsList[i]))
            {
                objectsList.Remove(objectsList[i]);
                i--;
            }
        }

        return objectsList;
    }

    public List<string> GetObjectNames()
    {
        GetAllObjects();
        objectNamesList.Clear();

        for (int i = 0; i < objectsList.Count; i++)
        {
            objectNamesList.Add(objectsList[i].name);
        }

        return objectNamesList;
    }

    public void SaveObjectNames(List<string> names)
    {
        string path = @"C:/Users/5047449/Desktop/Temp/" + fileName + ".txt";
        string result = "";

        for (int i = 0; i < names.Count; i++)
        {
            if (i == names.Count - 1)
            {
                result += names[i];
            }
            else
            {
                result += names[i] + "^";
            }
        }


        File.Delete(path);
        var file = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write);


        using (StreamWriter sw = new StreamWriter(file))
        {
            sw.Write(result);
        }
    }

    public List<string> LoadObjectNames()
    {
        string path = @"C:/Users/5047449/Desktop/Temp/" + fileName + ".txt";
        var file = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);

        string result;

        using (StreamReader sr = new StreamReader(file))
        {
            result = sr.ReadLine();
        }
        
        return result?.Split('^').ToList();
    }

    public void CreateObjects(List<string> objectNames)
    {
        for (int i = 0; i < objectsList.Count; i++)
        {
            var obj = Instantiate(objectsList[i], spawnPos.transform.position, Quaternion.identity);
            obj.name = objectNames[i];
        }
    }
}