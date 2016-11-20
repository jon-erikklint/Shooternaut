using UnityEngine;
using System.Collections;
using System;

public class CarriableItem : Grabbable
{
    private Actor carrier;
    private Transform lastParent;

    private Rigidbody2D trb;
    private Collider2D col;

    void Awake()
    {
        trb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
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

        Vector3 force = carrier.Angle() * carrier.Strength();

        transform.SetParent(lastParent);
        col.enabled = true;
        trb.isKinematic = false;
        trb.AddForce(force, ForceMode2D.Impulse);

        Rigidbody2D arb = actor.GetComponent<Rigidbody2D>();
        arb.mass = arb.mass - trb.mass;
        arb.AddForce(force * -1, ForceMode2D.Impulse);

        carrier = null;

        return true;
    }
}
