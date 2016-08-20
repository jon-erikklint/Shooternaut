using UnityEngine;
using System.Collections;
using System;

public class OverheatController : GunController {

    public float shootCharge;
    public float maxCharge;

    public float rechargeTime;
    public float rechargeCooldown;

    private float currentCharge;

    private float lastShot;

    public override void Initialize()
    {
        base.Initialize();

        currentCharge = maxCharge;

        lastShot = 0;
    }

    void Update()
    {
        Debug.Log(currentCharge);

        if(shootCharge == maxCharge)
        {
            return;
        }

        if(rechargeCooldown > Time.time - lastShot)
        {
            return;
        }

        float charge = maxCharge * (Time.deltaTime / rechargeTime);
        changeCharge(charge);
    }

    public override bool CanShoot()
    {
        if(currentCharge >= shootCharge)
        {
            SaveShot();

            return true;
        }

        return false;
    }

    private void SaveShot()
    {
        changeCharge(-shootCharge);

        lastShot = Time.time;
    }

    private void changeCharge(float amount)
    {
        currentCharge = Math.Max(0, Math.Min(maxCharge, currentCharge+amount));
    }
}
