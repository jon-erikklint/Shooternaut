using UnityEngine;
using System.Collections;

public abstract class Projectile : Respawnable, Destroyable
{
    private bool isBeingDestroyed = false;

    public abstract int Damage();

    public virtual void OnHit() { }
    public virtual void OnDestruction() { }

    public abstract bool GetsDestroyed(string colliderTag);

    void OnCollisionEnter2D(Collision2D col)
    {
        OnHit();

        if (GetsDestroyed(col.collider.tag))
        {
            OnDestruction();
            DestroySelf();
        }
    }
}