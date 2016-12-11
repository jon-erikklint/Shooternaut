using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class Activateable : Respawnable{

    public Actor owner { get { return _owner; } }
    private Actor _owner;

    public bool active{ get { return _active; } }
    private bool _active = false;

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

    public virtual void Activate()
    {
        _active = true;
    }
    public virtual void Deactivate()
    {
        _active = false;
    }

    public virtual void SetOwner(Actor owner)
    {
        this._owner = owner;
    }

    public virtual void Reset()
    {
        _active = false;
    }

    public abstract bool CanActivate();
    public abstract bool FullActivate();
    public abstract float ActivateAmount();

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
}
