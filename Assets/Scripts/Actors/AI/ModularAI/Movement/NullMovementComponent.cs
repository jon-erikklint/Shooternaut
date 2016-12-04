using UnityEngine;
using System.Collections;
using System;

public class NullMovementComponent : MAIMovementComponent
{
    public override Vector2 NextDirection()
    {
        return Vector2.zero;
    }

    public override float NextMagnitude()
    {
        return 0;
    }

    public override bool WillMove()
    {
        return false;
    }
}
