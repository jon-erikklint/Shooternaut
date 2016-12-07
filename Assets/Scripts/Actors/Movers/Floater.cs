using UnityEngine;
using System.Collections;
using System;

public class Floater : Mover
{
    private Rigidbody2D orb;

    protected override void Init()
    {
        orb = owner.GetComponent<Rigidbody2D>();
    }

    public override void Move(Vector2 direction, float magnitude)
    {
        orb.MoveRotation((float)(Math.Atan2(direction.y, direction.x) * 180 / Math.PI));

        Vector2 changeVelocity = direction.normalized * magnitude - orb.velocity;

        float changeLength = Math.Min(changeVelocity.magnitude, magnitude);

        orb.AddForce(changeVelocity.normalized * changeLength, ForceMode2D.Force);
    }
}
