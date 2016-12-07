using UnityEngine;
using System.Collections;
using System;

public class TimeOverheatController : GunController {

    public float maxCharge;
    public float chargeUsagePerSecond;
    public float rechargeTime;
    public float rechargeCooldown;

    public float currentCharge { get { return _currentCharge; } }
    private float _currentCharge;

    private float lastShoot;
    private bool shooting;

    public override void Initialize()
    {
        base.Initialize();

        lastShoot = 0;
        _currentCharge = maxCharge;
    }

    public override bool TryToShoot()
    {
        bool shoot = currentCharge > 0;

        if (shoot)
        {
            shooting = true;
        }

        return shoot;
    }

    public override bool CanShoot()
    {
        return currentCharge > 0;
    }

    public override bool FullClip()
    {
        return currentCharge == maxCharge;
    }

    public override void Deactivate()
    {
        lastShoot = Time.time;
        shooting = false;
    }

    public override void Reset()
    {
        lastShoot = 0;
        _currentCharge = maxCharge;
    }

    private void AddCharge(float amount)
    {
        _currentCharge = Math.Max(0, (Math.Min(maxCharge, _currentCharge + amount)));
    }

    void Update()
    {
        if (shooting)
        {
            AddCharge(-chargeUsagePerSecond * Time.deltaTime);
        }
        else if(_currentCharge < maxCharge && rechargeCooldown < Time.time - lastShoot)
        {
            AddCharge(maxCharge * Time.deltaTime);
        }
    }

    public override string ToString()
    {
        return _currentCharge + "/" + maxCharge;
    }

}
