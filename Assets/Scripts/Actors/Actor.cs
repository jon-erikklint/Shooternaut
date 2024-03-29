﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class Actor : Respawnable{

    public HealthInterface health;

    public List<Activateable> activateables;
    public Activateable mainActivateable;
    public Activateable secondaryActivateable;

    public List<Mover> movers;
    public Mover mainMover;
    public Mover secondaryMover;

    public Grabbable grabbed;
    
    public float strength;
    public List<string> hitTags;

	private bool onGround;

    public float invulnerabilityTime;
    private float lastHit;

    void Awake()
    {
        InitializeActivateables();
        InitializeMovers();

        grabbed = null;
		onGround = false;
        lastHit = 0;
    }

    private void InitializeActivateables()
    {
        if(mainActivateable == null && activateables.Count > 0)
        {
            mainActivateable = activateables[0];
        }

        if(secondaryActivateable == null)
        {
            if(activateables.Count > 1)
            {
                secondaryActivateable = activateables[1];
            }
            else if(activateables.Count > 0)
            {
                secondaryActivateable = activateables[0];
            }
        }

        foreach (Activateable activateable in activateables)
        {
            activateable.SetOwner(this);
        }
    }

    private void InitializeMovers()
    {
        if (mainMover == null && movers.Count > 0)
        {
            mainMover = movers[0];
        }

        if (secondaryMover == null)
        {
            if (movers.Count > 1)
            {
                secondaryMover = movers[1];
            }
            else if (movers.Count > 0)
            {
                secondaryMover = movers[0];
            }
        }

        foreach (Mover mover in movers)
        {
            mover.SetOwner(this);
        }
    }

    public bool IsGrabbed()
    {
        return grabbed != null;
    }

    public Grabbable GrabbedItem()
    {
        return grabbed;
    }

    public void Grab()
    {
        Vector2 actorPosition = Position();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(actorPosition, 1);

        Grabbable closest = null;
        float distanceToClosest = 2;

        foreach(Collider2D collider in colliders)
        {
            Grabbable grabbable = collider.GetComponent<Grabbable>();

            if(grabbable != null)
            {
                if (!grabbable.CanGrab(this))
                {
                    continue;
                }

                Vector2 grabbablePosition = collider.transform.position;
                float distanceToGrabbable = (actorPosition - grabbablePosition).magnitude;

                if ( distanceToGrabbable < distanceToClosest)
                {
                    distanceToClosest = distanceToGrabbable;
                    closest = grabbable;
                }
            }
        }

        if(closest != null)
        {
            grabbed = closest;
            closest.Grab(this);
        }
    }

    public void ReleaseGrip()
    {
        if(grabbed != null)
        {
            grabbed.Release(this);
            grabbed = null;
        }
    }

    public void LoseHealth(float amount)
    {
        if(invulnerabilityTime < Time.time - lastHit)
        {
            lastHit = Time.time;

            health.LoseHealth(amount);

            TestDead();
        }
    }

    public void SetHealth(float amount)
    {
        health.SetHealth(amount);

        TestDead();
    }

    private void TestDead()
    {
        if (health.Dead())
        {
            Destroy();
        }
    }

    public virtual bool Hit(string tag)
    {
        return hitTags.Contains(tag);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Hit(collision.gameObject.tag))
        {
            Projectile proj = collision.gameObject.GetComponent<Projectile>();

            LoseHealth(proj.Damage());
        }
        else
        {
            onGround = true;
        }
    }

	public void OnCollisionExit2D(Collision2D collision)
	{
        if(!hitTags.Contains(collision.gameObject.tag))
            onGround = false;
		DoOnCollisionExit (collision);
	}

	public virtual void DoOnCollisionEnter (Collision2D collision) { }
	public virtual void DoOnCollisionExit (Collision2D collision) { }

    public override List<object> RespawnPointReached(RespawnPoint respawn)
    {
        return new List<object>();
    }

    public override bool Respawn(List<object> lastState)
    {
        lastHit = 0;

        health.Reset();

        return true;
	}

    public virtual Vector2 Position()
    {
        return transform.position;
    }

    public virtual Vector2 Angle()
    {
        return transform.right;
    }

    public virtual float Width()
    {
        Vector3 scale = transform.lossyScale;
        return Math.Max(scale.x, scale.y);
    }

    public virtual void SetAngle(Vector2 newAngle)
    {
        transform.right = newAngle;
    }

    public virtual Quaternion FacingQuaternion()
    {
        return transform.rotation;
    }

	public bool OnGround()
	{
		return onGround;
	}

    public virtual float Strength()
    {
        return strength;
    }

    public virtual Vector2 FeetPosition()
    {
        return Angle() * -1;
    }
}
