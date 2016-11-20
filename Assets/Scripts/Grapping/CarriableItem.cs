using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CarriableItem : Grabbable
{
    private Actor carrier;
    private Transform lastParent;

    private Rigidbody2D trb;
    private Collider2D col;

    private Vector3 start;

    void Awake()
    {
        trb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        start = transform.position;
    }

    public override bool CanGrab(Actor actor)
    {
        return carrier == null;
    }

    public override bool Grab(Actor actor)
    {
        if (!CanGrab(actor))
        {
            return false;
        }
        
        Rigidbody2D arb = actor.GetComponent<Rigidbody2D>();

        float totalMass = trb.mass + arb.mass;

        arb.velocity = (trb.velocity * (trb.mass / totalMass)) + (arb.velocity * (arb.mass / totalMass));
        arb.mass = totalMass;

        trb.isKinematic = true;
        trb.velocity = new Vector2();
        col.enabled = false;

        lastParent = transform.parent;
        transform.SetParent(actor.transform);
        transform.localPosition = new Vector3();

        carrier = actor;

        return true;
    }

    public override bool Release(Actor actor)
    {
        if (!actor.Equals(carrier))
        {
            return false;
        }

        Reset();

        Vector3 force = actor.Angle() * actor.Strength();
        trb.AddForce(force, ForceMode2D.Impulse);

        Rigidbody2D arb = actor.GetComponent<Rigidbody2D>();
        arb.AddForce(force * -1, ForceMode2D.Impulse);

        return true;
    }

    public override void Respawn(List<object> lastState)
    {
        Reset();

        trb.velocity = Vector3.zero;
        this.transform.position = start;
    }

    public override List<object> RespawnPointReached(RespawnPoint respawn)
    {
        return new List<object>();
    }

    public override void Reset()
    {
        transform.SetParent(lastParent);
        col.enabled = true;
        trb.isKinematic = false;

        if(carrier != null)
        {
            carrier.GetComponent<Rigidbody2D>().mass -= trb.mass;
            carrier = null;
        }
    }
}
