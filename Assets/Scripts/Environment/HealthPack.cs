using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class HealthPack : Respawnable
{
    public float healthAmount;

    public List<string> allowedTags;

    public bool resetAfterRespawn;

    void OnTriggerEnter2D(Collider2D col)
    {
        Collide(col);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Collide(col.collider);
    }

    public void Collide(Collider2D col)
    {
        if (!allowedTags.Contains(col.tag))
        {
            return;
        }

        Actor actor = col.GetComponent<Actor>();

        if (actor != null)
        {
            GiveHealth(actor.health);
        }
    }

    public void GiveHealth(HealthInterface health)
    {
        health.GetHealth(healthAmount);

        gameObject.SetActive(false);
    }

    public override bool Respawn(List<object> lastState)
    {
        if (resetAfterRespawn)
        {
            gameObject.SetActive(true);
        }

        return true;
    }

    public override List<object> RespawnPointReached(RespawnPoint respawn)
    {
        return new List<object>();
    }
}
