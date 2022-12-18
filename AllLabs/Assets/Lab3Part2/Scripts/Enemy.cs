using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab3Part2
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] public float speed = 10f;

        [SerializeField] public GameObject chest;

        private bool isMoving;
        private Hero hero;


        

        public void StartMovingToChest()
        {
            isMoving = true;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "chest")
            {
                isMoving = false;
            }
        }


        private void Update()
        {
            if (isMoving)
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position,
                    chest.gameObject.transform.position, Time.deltaTime * speed);

            }
        }
    }
}