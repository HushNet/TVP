using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerSlow : MonoBehaviour
{
    private List<GameObject> objectsInTrigger;

    public void Start()
    {
        objectsInTrigger = new List<GameObject>();
    }
    

    public void SetSlowRadius(float value)
    {
        GetComponent<CircleCollider2D>().radius = value;
    }

    public void SlowAll(float slowPercent, float slowTime)
    {
        for (int i = 0; i < objectsInTrigger.Count; i++)
        {
            if (objectsInTrigger[i].CompareTag("Player"))
            {
                Hero hero = objectsInTrigger[i].GetComponent<Hero>();
                if (!hero.isSlowed)
                {
                    hero.isSlowed = true;
                    var startSpeed = hero.maxSpeed;
                    hero.maxSpeed = hero.maxSpeed * (100-slowPercent) / 100;

                    StartCoroutine(ReturnSpeed(startSpeed, slowTime));
                    
                }
            }
        }


    }

    public IEnumerator ReturnSpeed(float startSpeed, float slowTime)
    {
        yield return new WaitForSeconds(slowTime);
        
        for (int i = 0; i < objectsInTrigger.Count; i++)
        {
            if (objectsInTrigger[i].CompareTag("Player"))
            {
                Hero hero = objectsInTrigger[i].GetComponent<Hero>();
                hero.maxSpeed = startSpeed;
                hero.isSlowed = false;
            }
        }
    }



    public void OnTriggerEnter2D(Collider2D col)
    {
        objectsInTrigger.Add(col.gameObject);
    }
    
}
