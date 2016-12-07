using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Handle : Grabbable
{
    public GameObject grabPoint;

    private Actor grabbed;
    private Transform previousParent;

    private FixedJoint2D fj;
    private Rigidbody2D trb;

    void Awake()
    {
        if (grabPoint == null)
        {
            grabPoint = this.gameObject;
        }

        fj = grabPoint.GetComponent<FixedJoint2D>();
        trb = grabPoint.GetComponent<Rigidbody2D>();
    }

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

        if (trb != null && !trb.isKinematic)
        {
            trb.velocity = rb.velocity;
        }

        rb.velocity = new Vector2();
        fj.connectedBody = rb;

        previousParent = actor.transform.parent;
        actor.transform.SetParent(grabPoint.transform);
        actor.transform.localPosition = Vector3.zero;

        return true;
    }

    public override bool Release(Actor actor)
    {
        if (!actor.Equals(grabbed))
        {
            return false;
        }

        Reset();

        return true;
    }

    public override void Reset()
    {
        if(grabbed != null)
        {
            Rigidbody2D rb = grabbed.GetComponent<Rigidbody2D>();

            fj.connectedBody = null;

            grabbed.transform.SetParent(previousParent);

            if(trb != null && !trb.isKinematic)
            {
                trb.velocity = rb.velocity;
                fj.connectedBody = trb;
            }
        }

        grabbed = null;
    }

    public override bool Respawn(List<object> lastState)
    {
        Reset();

        return true;
    }

    public override List<object> RespawnPointReached(RespawnPoint respawn)
    {
        return new List<object>();
    }
}
