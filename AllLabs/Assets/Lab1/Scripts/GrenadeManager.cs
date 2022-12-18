using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeManager : MonoBehaviour
{
   [SerializeField] public Grenade grenade;
   private Grenade spawnedGrenade;


   public Grenade SpawnGrenade(Vector3 camPoint, Vector3 pos)
   {
       spawnedGrenade = Instantiate(grenade, new Vector3(pos.x, pos.y),new Quaternion().normalized);
       spawnedGrenade.GetComponent<Rigidbody2D>().AddForce( camPoint * 3, ForceMode2D.Impulse);
       
       spawnedGrenade.GetComponentInChildren<Splash>().SetSplashRadius(spawnedGrenade.splashRadius);

       return spawnedGrenade;
   }
}
