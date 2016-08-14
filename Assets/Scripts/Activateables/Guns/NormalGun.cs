using UnityEngine;
using System.Collections;
using System;

public class NormalGun : ProjectileGun
{
    public GameObject projectilePrefab;

    public float KnockbackMultiplier;
    public float ShootForceMultiplier;

    public override GameObject Projectile()
    {
        return projectilePrefab;
    }

    public override Vector3 KnockBackAmount()
    {
        return - owner.transform.right * KnockbackMultiplier;
    }

    public override Vector3 ShootForce()
    {
        return owner.transform.right * ShootForceMultiplier;
    }
}
