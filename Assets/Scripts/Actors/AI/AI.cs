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
	private Vector3 startingRight;
    private float startingRotation;

    public bool active { get { return _active; } }
    private bool _active;

    private Deactivator deac;

    public override void Init()
    {
        startingPosition = transform.position;
		startingRight = transform.right.normalized;
        startingRotation = GetComponent<Rigidbody2D>().rotation;

        player = FindObjectOfType<Player>();
        deac = FindObjectOfType<Deactivator>();

        _active = true;
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
        //float playerAngle = (float) (Math.Atan2(vtp.y, vtp.x) * 180 / Math.PI);
        //float lookAngle = GetComponent<Rigidbody2D>().rotation;
        //float overflow = Math.Abs(lookAngle) + fov / 2 - 180;
    

        //if (Math.Abs(GetComponent<Rigidbody2D>().rotation - playerAngle) > fov / 2 || overflow < 0 && Math.Abs(playerAngle) > overflow) return false;
		if(Vector3.Dot(vtp.normalized, startingRight) < cosfov) return false;

        RaycastHit2D hit = Physics2D.Raycast(Position()+VectorToPlayer().normalized*Width(), VectorToPlayer());

        return hit.collider != null && hit.collider.tag.Equals("Player");
    }

    public override bool Hit(string tag)
    {
        return tag.Equals("PlayerBullet") || tag.Equals("Bullet");
    }

    public override bool Respawn(List<object> lastState)
    {
        deac.ActivateGameobject(gameObject, startingPosition, startingRotation, Vector3.zero);

        _active = true;
        Activate();

        return base.Respawn(lastState);
    }

    public override void DestroySelf()
    {
        deac.DeactivateGameObject(gameObject);

        Deactivate();
        _active = false;
    }

    protected virtual void Deactivate() { }
    protected virtual void Activate() {}

}
