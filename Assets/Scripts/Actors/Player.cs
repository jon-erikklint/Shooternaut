using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;
using System.Collections.Generic;

public class Player : Actor
{
    public UnityEvent playerActs;

    public float jumpForce = 10;

    private Transform looker;
    private Transform feet;

    private float feetLength;

    public override void Init()
    {
        looker = transform.FindChild("Look");
        feet = transform.FindChild("Feet");

        feetLength = feet.localPosition.magnitude;
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        SetAngle(mousePosition - transform.position);

        Act();
    }

    private void Act()
    {
        if(Input.GetMouseButtonDown(0))
        {
            playerActs.Invoke();
            SetActivateable(true, mainActivateable);
        }

        if (Input.GetMouseButtonDown(1))
        {
            playerActs.Invoke();
            SetActivateable(true, secondaryActivateable);
        }

        if (Input.GetMouseButtonUp(0))
        {
            SetActivateable(false, mainActivateable);
        }

        if (Input.GetMouseButtonUp(1))
        {
            SetActivateable(false, secondaryActivateable);
        }

        if (Input.GetKeyDown("k"))
        {
            playerActs.Invoke();

            if (!IsGrabbed())
            {
                base.Grab();
            }
            else
            {
                base.ReleaseGrip();
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            playerActs.Invoke();

            mainMover.Move(Angle(), jumpForce);
        }
    }

    private void SetActivateable(bool active, Activateable act)
    {
        act.SetActive(active);
    }

    protected override void DestroySelf(){}

    public override List<object> RespawnPointReached(RespawnPoint respawn)
    {
        List<object> list = base.RespawnPointReached(respawn);

        Vector3 spawnCoord = respawn.spawnpoint;
        spawnCoord.z = transform.position.z;

        list.Add(spawnCoord);

        return list;
    }

    public override bool Respawn(List<object> lastState)
    {
        int lastElement = lastState.Count - 1;

        Vector3 respawnLocation = (Vector3) lastState[lastElement];
        transform.position = respawnLocation;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        lastState.RemoveRange(lastElement, 1);
        return base.Respawn(lastState);
    }

    public override Vector2 Angle()
    {
        return looker.right;
    }

    public override void SetAngle(Vector2 newAngle)
    {
        looker.right = newAngle;
        
        feet.localPosition = newAngle.normalized*feetLength*-1;
    }

    public override Vector2 FeetPosition()
    {
        return feet.position;
    }

    public override Quaternion FacingQuaternion()
    {
        return looker.rotation;
    }

    public override bool Hit(string tag)
    {
        return tag.Equals("Bullet");
    }
}