using UnityEngine;
using System.Collections;
using System;

public class Handle : Grabbable
{
    private Actor grabbed;
    private Transform previousParent;

    public override bool CanGrab(Actor actor)
    {
        return grabbed == null;
    }

    public override bool Grab(Actor actor)
    {
        if (!CanGrab(actor))
        {
            return false;
        }

        grabbed = actor;

        Rigidbody2D rb = actor.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        rb.velocity = new Vector2();

        previousParent = actor.transform.parent;
        actor.transform.SetParent(transform);
        actor.transform.localPosition = Vector3.zero;

        return true;
    }

    public override bool Release(Actor actor)
    {
        if (!actor.Equals(grabbed))
        {
            return false;
        }

        Rigidbody2D rb = grabbed.GetComponent<Rigidbody2D>();

        rb.isKinematic = false;

        grabbed.transform.SetParent(previousParent);

        grabbed = null;

        return true;
    }
}
