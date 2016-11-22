﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;
using System.Collections.Generic;

public class Player : Actor
{
    public UnityEvent playerDies;
    public UnityEvent playerActs;

    public float jumpForce = 10;

    private Transform looker;

    public override void Init()
    {
        looker = transform.FindChild("Look");
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        looker.right = mousePosition - transform.position;

        Act();
    }

    private void Act()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SetActivateable(true, mainActivateable);
        }

        if (Input.GetMouseButtonDown(1))
        {
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
            mainMover.Move(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position, jumpForce);
        }
    }

    private void SetActivateable(bool active, Activateable act)
    {
        act.SetActive(active);
    }

    public override void DestroySelf()
    {
        playerDies.Invoke();
    }

    public override bool Hit(string tag)
    {
        playerActs.Invoke();

        return tag.Equals("Bullet");
    }

    public override List<object> RespawnPointReached(RespawnPoint respawn)
    {
        List<object> list = base.RespawnPointReached(respawn);
        
        list.Add(respawn.spawnpoint);

        return list;
    }

    public override void Respawn(List<object> lastState)
    {
        int lastElement = lastState.Count - 1;

        Vector3 respawnLocation = (Vector3) lastState[lastElement];

        this.transform.position = respawnLocation;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        lastState.RemoveRange(lastElement, 1);
        base.Respawn(lastState);
    }

    public override float Strength()
    {
        return 5;
    }

    public override Vector3 Angle()
    {
        return looker.right;
    }

    public override Quaternion FacingQuaternion()
    {
        return looker.rotation;
    }
}