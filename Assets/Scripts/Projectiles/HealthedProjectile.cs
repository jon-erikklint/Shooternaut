using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class HealthedProjectile : Projectile
{
    public int damage;
    public int startHealth;

    public List<string> hitTags;
    public List<float> hitDamages;

    public HealthInterface health;

    private Dictionary<string, float> damages;

    public override int Damage()
    {
        return damage;
    }

    public override bool GetsDestroyed(string colliderTag)
    {
        if (!damages.ContainsKey(colliderTag))
        {
            return false;
        }

        float damage = damages[colliderTag];

        health.LoseHealth(damage);

        return health.Dead();
    }

    public override void init()
    {
        damages = new Dictionary<string, float>();

        for (int i = 0; i < hitTags.Count; i++)
        {
            damages.Add(hitTags[i], hitDamages[i]);
        }

        initHealth();
    }

    private void initHealth()
    {
        if(health != null)
        {
            return;
        }

        health = GetComponent<HealthInterface>();

        if(health != null)
        {
            return;
        }

        if(startHealth <= 0)
        {
            health = gameObject.AddComponent<InfiniteHealth>();
        }
        else
        {
            Health healt = gameObject.AddComponent<Health>();
            healt.initialize(startHealth);

            this.health = healt;
        }
    }
}
