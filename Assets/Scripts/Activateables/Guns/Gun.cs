using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class Gun : Activateable
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
        return controller.CanShoot();
    }

    public virtual void KnockBack()
    {
        owner.GetComponent<Rigidbody2D>().AddForce(shooter.KnockBackAmount(), ForceMode2D.Impulse);
    }
    
}