using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;
using System.Collections.Generic;

public class Player : Actor
{
    public UnityEvent playerDies;
    public UnityEvent playerActs;

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
        if(Input.GetMouseButtonDown(0))
        {
            SetActivateable(true, mouseLeft);
        }

        if (Input.GetMouseButtonDown(1))
        {
            SetActivateable(true, mouseRight);
        }

        if (Input.GetMouseButtonUp(0))
        {
            SetActivateable(false, mouseLeft);
        }

        if (Input.GetMouseButtonUp(1))
        {
            SetActivateable(false, mouseRight);
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

    public Activateable GetRight()
    {
        if (mouseLeft.Equals(mouseRight))
        {
            return null;
        }

        return mouseRight;
    }

    public override List<object> RespawnPointReached(RespawnPoint respawn)
    {
        Debug.Log("millon");
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
}