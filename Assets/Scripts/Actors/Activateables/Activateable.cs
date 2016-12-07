using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class Activateable : Respawnable, Destroyable{

    public Actor owner { get { return _owner; } }
    private Actor _owner;

    public void SetActive(bool active)
    {
        if (active)
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
    }

    public abstract void Activate();
    public abstract void Deactivate();

    public virtual void SetOwner(Actor owner)
    {
        this._owner = owner;
    }

    public abstract void Reset();

    public abstract bool CanActivate();
    public abstract bool FullActivate();

    public override List<object> RespawnPointReached(RespawnPoint respawn)
    {
        return new List<object>();
    }

    public override bool Respawn(List<object> lastState)
    {
        Reset();

        return true;
    }

    public abstract ActivateableType Type();

    public override void DestroySelf()
    {
        Destroy(gameObject);
    }
}
