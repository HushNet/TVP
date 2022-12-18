using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab3Part2
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] public float maxSpeed = 10f;
        [SerializeField] public ChestScript chest;
        [SerializeField] public Enemy enemy;

        private Rigidbody2D rb;


        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            ChestScript.OnOpenEvent += EnemyMoving;
        }

        void Update()
        {
            Flip();
            float move = Input.GetAxis("Horizontal");

            rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

            OpeningChest();
        }

        void Flip()
        {
            if (Input.GetAxis("Horizontal") > 0)
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            if (Input.GetAxis("Horizontal") < 0)
                transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        public void EnemyMoving()
        {
            enemy.StartMovingToChest();
        }

        public void OpeningChest()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                chest.Open(this);
            }
        }
    }
}