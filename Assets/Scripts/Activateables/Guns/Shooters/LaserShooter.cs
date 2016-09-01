using UnityEngine;
using System.Collections;
using System;

public class LaserShooter : GunShooter
{
    public GameObject laserPrefab;

    public float knockback;
    
    private Laser laser;
    private bool shooting = false;

    public override void Shoot()
    {
        if (!shooting)
        {
            laser = (Instantiate(laserPrefab, Vector3.zero, Quaternion.identity) as GameObject).GetComponent<Laser>();

            shooting = true;
        }

        UpdateLaser();
    }

    public override void StopShooting()
    {
        shooting = false;

        DestroyLaser();
    }

    public override Vector3 KnockBackAmount()
    {
        return owner.Angle() * -knockback;
    }

    private void UpdateLaser()
    {
        laser.startPosition = owner.Position() + (owner.Angle() * 0.26f);
        laser.facingDirection = owner.Angle();
    }

    private void DestroyLaser()
    {
        if(laser != null)
        {
            Destroy(laser.gameObject);
        }
    }

    public override void Reset()
    {
        DestroyLaser();
    }
}
