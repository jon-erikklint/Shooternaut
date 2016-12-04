using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class AI : Actor
{
    protected Player player;

    private Vector3 startingPosition;
    private Quaternion startingRotation;

    public override void Init()
    {
        startingPosition = transform.position;
        startingRotation = transform.rotation;

        player = FindObjectOfType<Player>();
    }

    public Vector2 VectorToPlayer()
    {
        return player.Position() - Position();
    }

    public bool isPlayerNearby(float distance)
    {
        return (VectorToPlayer()).magnitude < distance;
    }

    public bool isPlayerBetween(float max, float min)
    {
        float distance = VectorToPlayer().magnitude;

        return distance < max && distance > min;
    }

    public bool isPlayerInLOS()
    {
        RaycastHit2D hit = Physics2D.Raycast(Position(), VectorToPlayer());

        return hit.collider.tag.Equals("Player");
    }

    public override void Respawn(List<object> lastState)
    {
        transform.position = startingPosition;
        transform.rotation = startingRotation;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        base.Respawn(lastState);
    }
}
