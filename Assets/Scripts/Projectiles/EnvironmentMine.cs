using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class EnvironmentMine : OnDeathCreatorProjectile, Respawnable {

    private Vector3 startPosition;

    public override void init()
    {
        base.init();
        
        startPosition = transform.position;
    }

    public override void DestroySelf()
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
        transform.position = startPosition;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.isKinematic = false;

        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }

    public List<object> RespawnPointReached(RespawnPoint respawn)
    {
        return new List<object>();
    }

    public void Respawn(List<object> lastState)
    {
        Activate();
    }
}
