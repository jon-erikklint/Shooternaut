using UnityEngine;
using System.Collections;
using System;

public class PlayerAMAI : MAIActivateableComponent
{
    public float minDistance;
    public float maxDistance;

    public bool needLOS;

    public override bool NextState()
    {
        if(needLOS && !ai.isPlayerInLOS())
        {
            return false;
        }

        return maxDistance < 0 || ai.isPlayerBetween(maxDistance, minDistance);
    }
}
