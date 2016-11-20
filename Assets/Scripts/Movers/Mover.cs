using UnityEngine;
using System.Collections;

public abstract class Mover: MonoBehaviour {

    protected Actor owner;

    public abstract void Move(Vector2 direction, float magnitude);

    public virtual void Init(Actor actor)
    {
        this.owner = actor;
    }
}
