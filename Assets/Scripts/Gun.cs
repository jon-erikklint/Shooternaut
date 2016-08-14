using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public abstract class Gun : Activateable
{

    public Projectile projectile;
    public GameObject owner;
    public float knockBack;

    /// <summary>
    /// 
    /// </summary>
    /// <returns>true if shoots, flase otherwise</returns>
    ///

    public override bool Act()
    {
        return Shoot();
    }

    public abstract bool Shoot();

    public void KnockBack()
    {
        Vector3 dir = owner.transform.right.normalized;
        owner.GetComponent<Rigidbody2D>().AddForce(knockBack * dir);
    }
}
