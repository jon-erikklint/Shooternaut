using UnityEngine;
using System.Collections;
using System;

public class InfiteHealth : MonoBehaviour, HealthInterface
{
    public bool Dead()
    {
        return false;
    }

    public void LoseHealth(float amount){}

    public void GetHealth(float amount){}

    public void Reset(){}

    public void SetHealth(float amount){}

    public override string ToString()
    {
        return "Infinite";
    }
}
