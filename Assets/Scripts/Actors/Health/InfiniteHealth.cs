using UnityEngine;
using System.Collections;
using System;

public class InfiniteHealth : HealthInterface
{
    public override bool FullHealth()
    {
        return true;
    }

    public override bool Dead()
    {
        return false;
    }

    public override void LoseHealth(float amount){}

    public override void GetHealth(float amount){}

    public override void Reset(){}

    public override void SetHealth(float amount){}

    public override string ToString()
    {
        return "Infinite";
    }

    public override float CurrentHealth()
    {
        return 1;
    }
}
