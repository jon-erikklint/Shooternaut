using UnityEngine;
using System.Collections;
using System;

public class Jetpack : Mover
{
    private Rigidbody2D orb;

    protected override void Init()
    {
        orb = owner.GetComponent<Rigidbody2D>();
    }

    public override void Move(Vector2 direction, float magnitude)
    {
        orb.AddForce(direction.normalized * magnitude, ForceMode2D.Force);
    }
}
