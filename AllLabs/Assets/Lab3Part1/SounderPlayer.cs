using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class SounderPlayer : MonoBehaviour, IPlaySound
    {
        public IEnumerator PlaySound()
        {
            var audioSource = GetComponent<AudioSource>();
            
            audioSource.Play();
            gameObject.transform.localScale *= 2;

            yield return new WaitForSeconds(4);
            audioSource.Stop();
        }
    }
}