using UnityEngine;
using System.Collections;

public abstract class Projectile : Destroyable
{
    public abstract int Damage();

    public abstract void OnHit();

    public abstract void OnDestruction();

    public abstract bool GetsDestroyed(string colliderTag);

    void OnCollisionEnter2D(Collision2D col)
    {
        OnHit();

        if (GetsDestroyed(col.collider.tag))
        {
            Destroy();
        }
    }

    public override void Destroy()
    {
        OnDestruction();
        Destroy(this.gameObject, 0.01f);
    }
}