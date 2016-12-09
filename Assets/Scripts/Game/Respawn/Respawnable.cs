using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using System;

public abstract class Respawnable: Destroyable {

    void Start()
    {
        FindObjectOfType<RespawnManager>().AddMe(this);

        Init();
    }

    public virtual void Init() { }

    public abstract List<object> RespawnPointReached(RespawnPoint respawn);

    public abstract bool Respawn(List<object> lastState);
}
