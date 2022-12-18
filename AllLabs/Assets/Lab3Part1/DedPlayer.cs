using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
    public class DedPlayer : MonoBehaviour, IPlaySound
    {
        public IEnumerator PlaySound()
        {
            var audioSource = GetComponent<AudioSource>();
            
            audioSource.Play();
            gameObject.transform.rotation = new Quaternion(0f, 0f, 180f,11f);

            yield return new WaitForSeconds(4);
            
            audioSource.Stop();
        }
    }
}