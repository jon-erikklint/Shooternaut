﻿using UnityEngine;
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

    private void StopShooting()
    {
        shooting = false;

        DestroyLaser();
    }

    public override void CantShoot()
    {
        StopShooting();
    }

    public override void Deactivate()
    {
        StopShooting();
    }

    public override Vector2 KnockBackAmount()
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

    public override bool AbleToShoot()
    {
        return true;
    }
}
