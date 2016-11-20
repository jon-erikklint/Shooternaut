using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class Grabbable: MonoBehaviour, Respawnable {

    public abstract bool CanGrab(Actor actor);

    public abstract bool Grab(Actor actor);
    public abstract bool Release(Actor actor);

    public abstract void Reset();

    public abstract void Respawn(List<object> lastState);
public abstract List<object> RespawnPointReached(RespawnPoint respawn);
}
