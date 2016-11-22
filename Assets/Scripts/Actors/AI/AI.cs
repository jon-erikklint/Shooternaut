using UnityEngine;
using System.Collections;
using System;

public abstract class AI : Actor
{
    protected Player player;

    public override void Init()
    {
        player = FindObjectOfType<Player>();
    }

    protected Vector2 VectorToPlayer()
    {
        return player.Position() - Position();
    }

    protected bool isPlayerNearby(float distance)
    {
        return (VectorToPlayer()).magnitude < distance;
    }

    protected bool isPlayerInLOS()
    {
        RaycastHit2D hit = Physics2D.Raycast(Position(), VectorToPlayer());

        return hit.collider.tag.Equals("Player");
    }
}
