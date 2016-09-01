using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Shooter : Actor
{
    public float activationDelay;

    private float startTime;

    private ClickingActivateable action;

    public override void init()
    {
        action = GetComponentInChildren<ClickingActivateable>();
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

    public override void Respawn(List<object> lastState)
    {
        base.Respawn(lastState);

        startTime = Time.time;
    }
}
