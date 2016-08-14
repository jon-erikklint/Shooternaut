using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    public GameObject projectile;
    public float launchForce = 1f;

    private Rigidbody2D rb;
    private Health health;

    private PointCounter counter;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = this.GetComponent<Health>();

        counter = FindObjectOfType<PointCounter>();
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.right = mousePosition - transform.position;
        if (Input.GetMouseButtonDown(1))
        {
            Shoot(mousePosition);
        }
    }

    void Shoot(Vector3 mousePos)
    {
        Vector3 dir = mousePos - transform.position;
        dir /= dir.magnitude;
        GameObject proj = Instantiate<GameObject>(projectile);
        proj.transform.position = transform.position + dir*0.5f;
        proj.GetComponent<Rigidbody2D>().velocity = rb.velocity;
        proj.GetComponent<Rigidbody2D>().AddForce(launchForce * dir);
        rb.AddForce(-launchForce * dir);

        counter.balls++;
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
            counter.balls--;
        }
    }
}