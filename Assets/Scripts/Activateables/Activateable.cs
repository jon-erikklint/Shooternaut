using UnityEngine;
using System.Collections;

public abstract class Activateable : Destroyable {

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

}
