using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class CarPlayer : MonoBehaviour, IPlaySound
    {
        public IEnumerator PlaySound()
        {
            var audioSource = GetComponent<AudioSource>();
            
            audioSource.Play();
            gameObject.transform.position =  Vector3.MoveTowards(transform.position, 
                new Vector3(0,transform.position.y,transform.position.z), 5f);


            yield return new WaitForSeconds(4);
            audioSource.Stop();
        }
    }
}