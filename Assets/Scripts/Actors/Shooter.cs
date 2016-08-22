using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Shooter : Actor
{
    public float activationDelay;

    private float startTime;

    private Activateable action;

    public override void init()
    {
        action = GetComponentInChildren<Activateable>();
        action.SetOwner(this);
        startTime = Time.time;
    }

    void Update()
    {
        if (activationDelay > Time.time - startTime) return;

        if (action.CanAct())
        {
            action.Act();
        }

        Act();
    }

    public virtual void Act() { }

    public override bool Hit(string tag)
    {
        return false;
    }
}
