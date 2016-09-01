using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class Actor : Destroyable, Respawnable {

    public HealthInterface health;
    public float invulnerabilityTime;

    private float lastHit;

    void Awake()
    {
        health = GetComponent<HealthInterface>();
        lastHit = 0;
        init();
    }

    public abstract void init();

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
            DestroySelf();
        }
    }

    public abstract bool Hit(string tag);

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Hit(collision.gameObject.tag))
        {
            Projectile proj = collision.gameObject.GetComponent<Projectile>();

            LoseHealth(proj.Damage());
        }
    }

    public virtual List<object> RespawnPointReached(RespawnPoint respawn)
    {
        return new List<object>();
    }

    public virtual void Respawn(List<object> lastState)
    {
        lastHit = 0;

        health.Reset();
    }

    public Vector3 Position()
    {
        return transform.position;
    }

    public Vector3 Angle()
    {
        return transform.right;
    }
}
