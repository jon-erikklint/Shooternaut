using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Shooter : Actor
{
    private Activateable action;

    public override void init()
    {
        action = GetComponentInChildren<Activateable>();
        action.SetOwner(this);
    }

    void Update()
    {
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
