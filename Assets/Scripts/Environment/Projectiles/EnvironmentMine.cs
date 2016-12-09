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

        gameObject.SetActive(false);
    }

    public void Activate()
    {
        gameObject.SetActive(true);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;

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
