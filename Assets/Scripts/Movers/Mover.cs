using UnityEngine;
using System.Collections;

public abstract class Mover: MonoBehaviour {

    protected Actor owner;

    public abstract void Move(Vector2 direction, float magnitude);

    public virtual void SetOwner(Actor actor)
    {
        this.owner = actor;

        Init();
    }

    protected abstract void Init();
}
