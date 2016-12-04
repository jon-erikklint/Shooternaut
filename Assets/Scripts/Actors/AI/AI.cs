using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class AI : Actor
{
    protected Player player;

    private Vector3 startingPosition;
    private float startingRotation;

    public bool active { get { return _active; } }
    private bool _active;

    public override void Init()
    {
        startingPosition = transform.position;
        startingRotation = GetComponent<Rigidbody2D>().rotation;

        player = FindObjectOfType<Player>();

        _active = true;
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
        RaycastHit2D hit = Physics2D.Raycast(Position()+Angle().normalized*Width(), VectorToPlayer());

        return hit.collider.tag.Equals("Player");
    }

    public override void Respawn(List<object> lastState)
    {
        transform.position = startingPosition;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        rb.rotation = startingRotation;


        GetComponent<Collider2D>().enabled = true;
        GetComponent<Renderer>().enabled = true;
        _active = true;

        base.Respawn(lastState);
    }

    public override void DestroySelf()
    {
        GetComponent<Collider2D>().enabled = false;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        GetComponent<Renderer>().enabled = false;

        _active = false;
    }

}
