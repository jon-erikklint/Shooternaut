using UnityEngine;
using System.Collections;
using System;

public class ConstantMMAI : MAIMovementComponent {

    public Vector2 movementDirection;
    public float movementMagnitude;

    public override Vector2 NextDirection()
    {
        return movementDirection;
    }

    public override float NextMagnitude()
    {
        return movementMagnitude;
    }

    public override bool WillMove()
    {
        return true;
    }
}
