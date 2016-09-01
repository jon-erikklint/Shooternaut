using UnityEngine;
using System.Collections;
using System;

public abstract class ProjectileShooter : GunShooter
{
    public abstract GameObject Projectile();

    public override void Shoot()
    {
        GameObject projectile = createProjectile();

        SetProjectileSpeed(projectile);
    }

    private GameObject createProjectile()
    {
        Vector3 offset = owner.transform.right;
        offset.Scale(new Vector3(0.5f, 0.5f, 0.5f));

        Vector3 spawnPosition = owner.transform.position + offset;
        return Instantiate(Projectile(), spawnPosition, owner.transform.rotation) as GameObject;
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

    public override void StopShooting(){}
}