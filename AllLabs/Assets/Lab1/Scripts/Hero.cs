using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] public float maxSpeed = 10f;
    [SerializeField] public Camera cam;
    [SerializeField] public GrenadeManager grenadeManager;

    private Rigidbody2D rb;

    public bool isSlowed = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GrenadeThrowing();
        Flip();
        float move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    public void GrenadeThrowing()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var camPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            var pos = this.transform.localPosition;

            var spawnedGrenade = grenadeManager.SpawnGrenade(camPoint, pos);
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), spawnedGrenade.GetComponent<CircleCollider2D>());
            
            spawnedGrenade.StartDetonator();
        }
    }
}