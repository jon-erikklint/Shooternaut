using UnityEngine;
using System.Collections;
using System;

public abstract class ProjectileShooter : GunShooter
{
    public abstract GameObject Projectile();
    public abstract float ProjectileRadius();

    public override bool AbleToShoot()
    {
        return Physics2D.OverlapCircleAll(CreationPoint(), ProjectileRadius()).Length == 0;
    }

    public override void Shoot()
    {
        GameObject projectile = CreateProjectile();

        SetProjectileSpeed(projectile);
    }

    private Vector3 CreationPoint()
    {
        Vector2 offset = FacedDirection();
        Vector2 realOffset = new Vector3(owner.Width()*offset.x, owner.Width()*offset.y, 0);

        return owner.Position() + realOffset;
    }

    private GameObject CreateProjectile()
    {
        return Instantiate(Projectile(), CreationPoint(), owner.FacingQuaternion()) as GameObject;
    }

    private void SetProjectileSpeed(GameObject proj)
    {
        Rigidbody2D ownerbody = owner.GetComponent<Rigidbody2D>();
        Rigidbody2D projbody = proj.GetComponent<Rigidbody2D>();

        Vector2 startSpeedAddition = new Vector2(ownerbody.velocity.x * projbody.mass, ownerbody.velocity.y * projbody.mass);
        Vector2 projectileVelocity = ShootForce() + startSpeedAddition;

        projbody.AddForce(projectileVelocity, ForceMode2D.Impulse);
    }

    public abstract Vector2 ShootForce();

    public override void CantShoot(){}
    public override void Deactivate(){}
}