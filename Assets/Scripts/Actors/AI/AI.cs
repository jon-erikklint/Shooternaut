using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class AI : Actor
{
    public float fov;
	private float cosfov;

    protected Player player;

    private Vector3 startingPosition;
    private float startingRotation;

    public override void Init()
    {
        startingPosition = transform.position;
        startingRotation = GetComponent<Rigidbody2D>().rotation;

        player = FindObjectOfType<Player>();
        
		cosfov = Mathf.Cos(fov*Mathf.PI/360);
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
        Vector2 vtp = VectorToPlayer();
		if(Vector2.Dot(vtp.normalized, Angle().normalized) < cosfov) return false;

        RaycastHit2D hit = Physics2D.Raycast(Position()+VectorToPlayer().normalized*Width(), VectorToPlayer());

        return hit.collider != null && hit.collider.tag.Equals("Player");
    }

    public override bool Hit(string tag)
    {
        return tag.Equals("PlayerBullet") || tag.Equals("Bullet");
    }

    public override bool Respawn(List<object> lastState)
    {
        gameObject.SetActive(true);
        transform.position = startingPosition;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        rb.rotation = startingRotation;
        
        Activate();

        return base.Respawn(lastState);
    }

    protected override void DestroySelf()
    {
        gameObject.SetActive(false);

        Deactivate();
    }

    protected virtual void Deactivate() { }
    protected virtual void Activate() {}

}
