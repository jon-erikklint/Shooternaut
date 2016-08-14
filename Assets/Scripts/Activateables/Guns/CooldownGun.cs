using UnityEngine;
using System.Collections;

public class CooldownGun : NormalGun {

    public float coolDownTime;
    private float prevFire;

    void Start()
    {
        prevFire = 0;
    }

    public override bool CanShoot()
    {
        if (Time.time - prevFire < coolDownTime) return false;
        prevFire = Time.time;
        return true;
    }
}
