using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Shooter : Actor
{
    private Gun gun;

    public override void init()
    {
        gun = GetComponentInChildren<Gun>();
        gun.owner = this;
    }

    void Update()
    {
        if (gun.CanShoot())
        {
            gun.Shoot();
        }

        Act();
    }

    public virtual void Act() { }

    public override bool Hit(string tag)
    {
        return false;
    }
}
