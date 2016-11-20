using UnityEngine;
using System.Collections;

public abstract class Grabbable: MonoBehaviour {

    public abstract bool CanGrab(Actor actor);

    public abstract bool Grab(Actor actor);
    public abstract bool Release(Actor actor);
}
