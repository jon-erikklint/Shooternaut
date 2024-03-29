﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class Gun : ClickingActivateable
{
    private GunController controller;
    private GunShooter shooter;

    public override void SetOwner(Actor owner)
    {
        base.SetOwner(owner);

        controller = GetComponent<GunController>();
        shooter = GetComponent<GunShooter>();

        controller.Initialize();
        shooter.Initialize();
    }

    public override void Act()
    {
        shooter.Shoot();
        KnockBack();
    }

    public override bool CanAct()
    {
        return controller.TryToShoot(); //&& shooter.AbleToShoot();
    }

    public override void Deactivate()
    {
        base.Deactivate();

        shooter.Deactivate();
        controller.Deactivate();
    }

    public override void CantActAnymore()
    {
        shooter.CantShoot();
    }

    public virtual void KnockBack()
    {
        owner.GetComponent<Rigidbody2D>().AddForce(shooter.KnockBackAmount(), ForceMode2D.Impulse);
    }

    public override void Reset()
    {
        base.Reset();

        shooter.Reset();
        controller.Reset();
    }

    public override bool CanActivate()
    {
        return controller.CanShoot();
    }

    public override bool FullActivate()
    {
        return controller.FullClip();
    }

    public override ActivateableType Type()
    {
        return ActivateableType.Gun;
    }

    public override float ActivateAmount()
    {
        return controller.Amount();
    }

    public override string ToString()
    {
        return controller.ToString();
    }
}