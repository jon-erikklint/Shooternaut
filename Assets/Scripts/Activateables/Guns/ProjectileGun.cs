using UnityEngine;
using System.Collections;
using System;

public abstract class ProjectileGun : Gun
{
    public abstract GameObject Projectile();

    public override void Shoot()
    {
        Vector3 offset = owner.transform.right;
        offset.Scale(new Vector3(0.5f, 0.5f, 0.5f));

        Vector3 spawnPosition = owner.transform.position + offset;
        GameObject proj = Instantiate(Projectile(), spawnPosition, owner.transform.rotation) as GameObject;

        Vector2 ownerVelocity = owner.GetComponent<Rigidbody2D>().velocity;

        Vector3 projectileVelocity = ShootForce();
        projectileVelocity += new Vector3(ownerVelocity.x, ownerVelocity.y, 0);

        proj.GetComponent<Rigidbody2D>().AddForce(projectileVelocity);
    }

    public abstract Vector3 ShootForce();
}