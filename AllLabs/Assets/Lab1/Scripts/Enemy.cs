using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int health = 100;

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameObject.GetComponent<ParticleSystem>().Play();
            StartCoroutine(SelfDestroy());
        }
    }

    public void SetHp(int value)
    {
        health = value;
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
    
}
