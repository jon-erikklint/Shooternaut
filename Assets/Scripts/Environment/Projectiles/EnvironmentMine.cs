using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class EnvironmentMine : OnDeathCreatorProjectile{

    public Vector3 startVelocity;

    private Vector3 startPosition;

    private Rigidbody2D rb;

    public override void Init()
    {
        base.Init();

        rb = GetComponent<Rigidbody2D>();

        startPosition = transform.position;

        AddVelocity();
    }

    protected override void DestroySelf()
    {
        OnDestruction();

        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
    }

    public void Activate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.isKinematic = false;

        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;

        transform.position = startPosition;
        AddVelocity();
    }

    private void AddVelocity()
    {
        rb.AddForce(startVelocity * rb.mass, ForceMode2D.Impulse);
    }

    public override List<object> RespawnPointReached(RespawnPoint respawn)
    {
        return new List<object>();
    }

    public override bool Respawn(List<object> lastState)
    {
        Activate();

        return true;
    }
}
