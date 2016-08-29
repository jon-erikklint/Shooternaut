using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class Activateable : Destroyable, Respawnable {

    public Actor owner{get{ return _owner; }}
    private Actor _owner;

    public virtual void SetOwner(Actor owner)
    {
        this._owner = owner;
    }

    public abstract bool CanAct();
    public abstract void Act();

    public abstract void Reset();

    public abstract GameObject UIElement();

    public List<object> RespawnPointReached(RespawnPoint respawn)
    {
        return new List<object>();
    }

    public void Respawn(List<object> lastState)
    {
        Reset();
    }
}
