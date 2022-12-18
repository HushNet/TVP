using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Splash : MonoBehaviour
{
    public List<GameObject> objectsInDetonateRadius;


    public void SetSplashRadius(float value)
    {
        GetComponent<CircleCollider2D>().radius = value;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        objectsInDetonateRadius.Add(col.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        objectsInDetonateRadius.Remove(other.gameObject);
    }
}
