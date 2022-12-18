using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab3Part2
{
    public class ChestScript : MonoBehaviour
    {
        public List<GameObject> objectsInTrigger;

        public static event Action OnOpenEvent;


        public void Open(Hero hero)
        {
            if (objectsInTrigger.Contains(hero.gameObject))
            {
                OnOpenEvent.Invoke();
            }


            for (int i = 0; i < objectsInTrigger.Count; i++)
            {
                Debug.Log($"Сундук открыт: {hero.gameObject.name}");
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            objectsInTrigger.Add(col.gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            objectsInTrigger.Remove(other.gameObject);
        }
    }
}