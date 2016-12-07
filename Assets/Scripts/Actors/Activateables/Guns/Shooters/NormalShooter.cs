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

    private float BulletMass()
    {
        Rigidbody2D rb = projectilePrefab.GetComponent<Rigidbody2D>();

        return rb.mass;
    }

    public override Vector2 KnockBackAmount()
    {
        return -FacedDirection() * (KnockbackMultiplier * BulletMass());
    }

    public override Vector2 ShootForce()
    {
        return FacedDirection() * (ShootForceMultiplier * BulletMass());
    }

    public override float ProjectileRadius()
    {
        Vector3 scale = projectilePrefab.transform.lossyScale;

        return Math.Max(scale.x, scale.y);
    }
}
