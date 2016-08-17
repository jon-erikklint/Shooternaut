using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class Player : Actor
{
    public UnityEvent playerDies;
    public UnityEvent playerActs;

    public RespawnManager respawnPoint;

    public Activateable mouseLeft;
    public Activateable mouseRight;

    public override void init(){}

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
            mouseLeft.Act();
            playerActs.Invoke();
        }

        if (Input.GetMouseButtonDown(1))
        {
            mouseRight.Act();
            playerActs.Invoke();
        }
    }

    public override void DestroySelf()
    {
        Debug.Log("DIE");
        playerDies.Invoke();
    }

    public override bool Hit(string tag)
    {
        return tag.Equals("Bullet");
    }
}