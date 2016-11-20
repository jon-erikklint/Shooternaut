using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Activateable : Destroyable, Respawnable {

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

    public abstract GameObject UIElement();

    public abstract bool CanActivate();
    public abstract bool FullActivate();

    public List<object> RespawnPointReached(RespawnPoint respawn)
    {
        return new List<object>();
    }

    public void Respawn(List<object> lastState)
    {
        Reset();
    }

    public abstract ActivateableType Type();
    
}
