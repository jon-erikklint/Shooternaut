using UnityEngine;
using System.Collections;
using System;

public class ChaserMMAI : MAIMovementComponent {

    public float speed;

    private bool hasSeenPlayer = false;

    public override Vector2 NextDirection()
    {
        if (hasSeenPlayer)
        {
            return ai.VectorToPlayer();
        }

        return Vector3.zero;
    }

    public override float NextMagnitude()
    {
        return speed;
    }

    public override bool WillMove()
    {
        if (hasSeenPlayer)
        {
            return true;
        }

        hasSeenPlayer = ai.isPlayerInLOS();

        return hasSeenPlayer;
    }
}
