using UnityEngine;
using System.Collections;

public abstract class Projectile : Destroyable
{
    private bool isBeingDestroyed = false;

    void Start()
    {
        init();
    }

    public abstract void init();

    public abstract int Damage();

    public virtual void OnHit() { }

    public virtual void OnDestruction() { }

    public abstract bool GetsDestroyed(string colliderTag);


    void OnCollisionEnter2D(Collision2D col)
    {
        OnHit();

        if (GetsDestroyed(col.collider.tag))
        {
            this.GetComponent<Renderer>().enabled = false;
            isBeingDestroyed = true;
        }

        
    }

    void OnCollisionExit2D(Collision2D col)
    {

        if (isBeingDestroyed)
        {
            DestroySelf();
        }
    }

    public override void DestroySelf()
    {
        OnDestruction();
        Destroy(this.gameObject, 0.01f);
    }
}