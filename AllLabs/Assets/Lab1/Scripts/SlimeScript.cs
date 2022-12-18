using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    [SerializeField] public float triggerRadius;
    [SerializeField] public float slowRadius;
    [SerializeField]  [Range (0, 100)] public int slowPercent;
    [SerializeField] public float slowTimeSec;
    [SerializeField] public Sprite trapSprite;

    private TriggerSlow triggerSlow;
    private bool isActive = true;

    public void Start()
    {
        triggerSlow = GetComponentInChildren<TriggerSlow>();
        GetComponentInChildren<SpriteRenderer>().sprite = trapSprite;
        triggerSlow.SetSlowRadius(slowRadius);
        GetComponent<CircleCollider2D>().radius = triggerRadius;
        isActive = true;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (isActive)
        {
            triggerSlow.SlowAll(slowPercent, slowTimeSec);
            StartCoroutine(SelfDestroy());
        }
           
    }
    
    private IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(0.5f);

        GetComponentInChildren<SpriteRenderer>().sprite = null;

        isActive = false;
        
        yield return new WaitForSeconds(slowTimeSec * 1.5f);
        
        Destroy(this.gameObject);
    }
}
