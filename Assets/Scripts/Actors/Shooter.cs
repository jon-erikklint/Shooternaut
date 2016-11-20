using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Shooter : Actor
{
    public float activationDelay;

    public override void Init()
    {
        Invoke("StartToShoot", activationDelay);
    }

    void StartToShoot()
    {
        mainActivateable.Activate();
    }

    public override bool Hit(string tag)
    {
        return false;
    }

    public override void Respawn(List<object> lastState)
    {
        base.Respawn(lastState);

        Init();
    }
}
