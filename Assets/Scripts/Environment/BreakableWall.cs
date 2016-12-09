using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BreakableWall : Respawnable
{
    public float momentumBreakLimit;

    public bool saveStateOverRespawn;
    
    public bool broken { get { return _broken; } }
    private bool _broken;

    public override void Init()
    {
        _broken = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        float momentum = col.rigidbody.velocity.magnitude * col.rigidbody.mass;

        if(momentum >= momentumBreakLimit)
        {
            Break();
        }
    }

    public void Break()
    {
        _broken = true;
        gameObject.SetActive(false);
    }

    public void Fix()
    {
        _broken = false;
        gameObject.SetActive(true);
    }

    public override bool Respawn(List<object> lastState)
    {
        if (!saveStateOverRespawn)
        {
            Fix();
        }

        return true;
    }

    public override List<object> RespawnPointReached(RespawnPoint respawn)
    {
        return new List<object>();
    }
}
