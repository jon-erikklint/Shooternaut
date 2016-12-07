using UnityEngine;
using System.Collections;
using System;

public class CooldownController : GunController {

    public float coolDownTime;
    private float prevFire;

    public override void Initialize()
    {
        base.Initialize();

        prevFire = -2 * coolDownTime;
    }

    public override bool TryToShoot()
    {
        if (!CanShoot()) return false;

        prevFire = Time.time;
        return true;
    }

    public override bool CanShoot()
    {
        return Time.time - prevFire >= coolDownTime;
    }

    public override bool FullClip()
    {
        return CanShoot();
    }

    public override void Reset()
    {
        prevFire = 0;
    }

    public override string ToString()
    {
        return "Cooldown: "+(Math.Max(prevFire + coolDownTime - Time.time, 0)).ToString("0.00");
    }
}
