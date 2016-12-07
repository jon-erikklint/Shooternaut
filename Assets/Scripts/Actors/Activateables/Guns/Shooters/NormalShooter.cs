using UnityEngine;
using System.Collections;
using System;

public class NormalShooter : ProjectileShooter
{
    public GameObject projectilePrefab;

    public float KnockbackMultiplier;
    public float ShootForceMultiplier;

    public override GameObject Projectile()
    {
        return projectilePrefab;
    }

    private float bulletMass()
    {
        Rigidbody2D rb = projectilePrefab.GetComponent<Rigidbody2D>();

        return rb.mass;
    }

    public override Vector3 KnockBackAmount()
    {
        return -FacedDirection() * (KnockbackMultiplier * bulletMass());
    }

    public override Vector3 ShootForce()
    {
        return FacedDirection() * (ShootForceMultiplier * bulletMass());
    }

    public override float ProjectileRadius()
    {
        Vector3 scale = projectilePrefab.transform.lossyScale;

        return Math.Max(scale.x, scale.y);
    }
}
