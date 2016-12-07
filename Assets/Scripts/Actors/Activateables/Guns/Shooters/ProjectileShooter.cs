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
        GameObject projectile = createProjectile();

        SetProjectileSpeed(projectile);
    }

    private Vector3 CreationPoint()
    {
        Vector3 offset = owner.Angle();
        offset.Scale(new Vector3(0.5f, 0.5f, 0.4f));

        return owner.Position() + offset;
    }

    private GameObject createProjectile()
    {
        return Instantiate(Projectile(), CreationPoint(), owner.FacingQuaternion()) as GameObject;
    }

    private void SetProjectileSpeed(GameObject proj)
    {
        Rigidbody2D ownerbody = owner.GetComponent<Rigidbody2D>();
        Rigidbody2D projbody = proj.GetComponent<Rigidbody2D>();
        Vector3 startSpeedAddition = new Vector3(ownerbody.velocity.x * projbody.mass, ownerbody.velocity.y * projbody.mass, 0);

        Vector3 projectileVelocity = ShootForce() + startSpeedAddition;

        projbody.AddForce(projectileVelocity, ForceMode2D.Impulse);
    }

    public abstract Vector3 ShootForce();

    public override void CantShoot(){}
    public override void Deactivate(){}
}