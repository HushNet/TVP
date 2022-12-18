using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] public float timeToDetonate = 3f;
    [SerializeField] public int damage = 3;
    [SerializeField] public float splashRadius = 1.5f;

    private Grenade currentGrenade;


    public void StartDetonator()
    {
        StartCoroutine(DetonatorTimer());
    }
    public IEnumerator DetonatorTimer()
    {
        yield return new WaitForSeconds(timeToDetonate);
        GetComponentInChildren<ParticleSystem>().Play();
        var objectsInDetonateRadius = GetComponentInChildren<Splash>().objectsInDetonateRadius;
        for (int i = 0; i < objectsInDetonateRadius.Count; i++)
        {
            objectsInDetonateRadius[i].GetComponent<Enemy>()?.Damage(damage);
        }

        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    

    
}
