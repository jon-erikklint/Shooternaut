using UnityEngine;
using System.Collections;

public class CooldownController : GunController {

    public float coolDownTime;
    private float prevFire;

    public override void Initialize()
    {
        base.Initialize();

        prevFire = 0;
    }

    public override bool CanShoot()
    {
        if (Time.time - prevFire < coolDownTime) return false;

        prevFire = Time.time;
        return true;
    }
}
