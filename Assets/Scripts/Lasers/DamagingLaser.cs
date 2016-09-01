using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class DamagingLaser : Laser {
    
    public float damage;

    public override void OnHit(RaycastHit2D hit)
    {
        Actor actor = hit.collider.GetComponent<Actor>();
        if(actor != null)
        {
            actor.LoseHealth(damage);
        }
    }
}
