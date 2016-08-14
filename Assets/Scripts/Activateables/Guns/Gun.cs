using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public abstract class Gun : Activateable
{
    public override bool Act()
    {
        if (CanShoot())
        {
            Shoot();
            KnockBack();
            return true;
        }

        return false;
    }


    public virtual bool CanShoot()
    {
        return true;
    }

    public abstract void Shoot();

    public virtual void KnockBack()
    {
        owner.GetComponent<Rigidbody2D>().AddForce(KnockBackAmount());
    }

    public abstract Vector3 KnockBackAmount();
    
}