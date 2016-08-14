using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public abstract class Gun : Activateable
{

    /// <summary>
    /// 
    /// </summary>
    /// <returns>true if shoots, flase otherwise</returns>
    ///

    public override bool Act()
    {
        bool shot = Shoot();
        if (shot)
        {
            KnockBack();
        }

        return false;
    }

    public void KnockBack()
    {
        Vector3 knockback = KnockBackAmount();
        owner.GetComponent<Rigidbody2D>().AddForce(knockback);
    }

    public abstract bool Shoot();

    public abstract Vector3 KnockBackAmount();

    
}
