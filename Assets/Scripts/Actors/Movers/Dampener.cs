using UnityEngine;
using System.Collections;
using System;

public class Dampener : Mover
{
    protected override void Init(){}

    public override void Move(Vector2 direction, float magnitude)
    {
        Rigidbody2D orb = owner.GetComponent<Rigidbody2D>();

        float damperingStrength = Math.Min(magnitude*Time.deltaTime, orb.velocity.magnitude);

        orb.velocity -= orb.velocity.normalized * damperingStrength;
    }
}
