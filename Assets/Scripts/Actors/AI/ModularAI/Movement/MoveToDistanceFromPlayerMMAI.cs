using UnityEngine;
using System.Collections;
using System;

public class MoveToDistanceFromPlayerMMAI : MAIMovementComponent
{
    public bool needLOS;
    public float maxDistanceToPlayer;
    public float minDistanceToPlayer;

    public float speed;

    public override Vector2 NextDirection()
    {
        Vector2 vector = ai.VectorToPlayer();

        if (minDistanceToPlayer < 0 || ai.isPlayerNearby(minDistanceToPlayer)) return vector * -1;
        return vector;
    }

    public override float NextMagnitude()
    {
        return speed;
    }

    public override bool WillMove()
    {
        if(needLOS && !ai.isPlayerInLOS())
        {
            return false;
        }

        if(maxDistanceToPlayer < 0 || minDistanceToPlayer < 0)
        {
            return true;
        }

        return ai.isPlayerNearby(maxDistanceToPlayer);
    }
}
