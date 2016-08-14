using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    public Activateable mouseLeft;
    public Activateable mouseRight;

    private Rigidbody2D rb;
    private Health health;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = this.GetComponent<Health>();
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.right = mousePosition - transform.position;
    }

    private void Act()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseLeft.Act();
        }

        if (Input.GetMouseButtonDown(1))
        {
            mouseRight.Act();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(health == null)
        {
            return;
        }

        if (collision.gameObject.tag.Equals("bullet"))
        {
            health.loseHealth(1);
        }
    }
}