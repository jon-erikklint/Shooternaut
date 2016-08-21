using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;
using System.Collections.Generic;

public class Player : Actor
{
    public UnityEvent playerDies;
    public UnityEvent playerActs;

    public RespawnManager respawnPoint;

    public Activateable mouseLeft;
    public Activateable mouseRight;

    public override void init()
    {
        mouseLeft.SetOwner(this);
        mouseRight.SetOwner(this);
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.right = mousePosition - transform.position;

        Act();
    }

    private void Act()
    {
        if(Input.GetMouseButton(0))
        {
            ActivateableAct(mouseLeft);
        }

        if (Input.GetMouseButton(1))
        {
            ActivateableAct(mouseRight);
        }
    }

    private void ActivateableAct(Activateable act)
    {
        if (act.CanAct())
        {
            act.Act();
            playerActs.Invoke();
        }
    }

    public override void DestroySelf()
    {
        playerDies.Invoke();
    }

    public override bool Hit(string tag)
    {
        return tag.Equals("Bullet");
    }

    public Activateable GetRight()
    {
        if (mouseLeft.Equals(mouseRight))
        {
            return null;
        }

        return mouseRight;
    }
}