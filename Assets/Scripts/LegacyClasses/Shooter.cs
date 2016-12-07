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

    public override bool Respawn(List<object> lastState)
    {
        Init();

        return base.Respawn(lastState);
    }
}
