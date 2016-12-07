using UnityEngine;
using System.Collections;
using System;

public abstract class GunController : MonoBehaviour{

    private Gun gun;
    public Actor owner;

    public virtual void Initialize()
    {
        gun = GetComponent<Gun>();
        owner = gun.owner;
    }

    public abstract bool TryToShoot();
    public abstract bool CanShoot();
    public abstract bool FullClip();

    public virtual void Deactivate() { }

    public abstract void Reset();
    
}
