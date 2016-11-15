using UnityEngine;
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
        return controller.TryToShoot();
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

    public override GameObject UIElement()
    {
        GameObject uiElement = transform.GetChild(0).gameObject;
        uiElement.GetComponent<GunUI>().gun = controller;

        return uiElement;
    }

    public override void Reset()
    {
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
}