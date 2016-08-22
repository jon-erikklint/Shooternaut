﻿using UnityEngine;
using System.Collections;
using System;

public class OverheatController : GunController {

    public float shootCharge;
    public float maxCharge;

    public float rechargeTime;
    public float rechargeCooldown;

    public float shootCooldown;

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
        if(currentCharge >= shootCharge && Time.time - lastShot > shootCooldown)
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

    public override string ToString()
    {
        return currentCharge.ToString("0.00")+"/"+maxCharge.ToString("0.00");
    }

    public override void Reset()
    {
        currentCharge = maxCharge;
        lastShot = 0;
    }
}