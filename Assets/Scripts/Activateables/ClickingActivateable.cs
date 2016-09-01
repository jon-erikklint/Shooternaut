using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class ClickingActivateable : Activateable{

    public bool active { get { return _active; } }
    private bool _active;

    public override void Activate()
    {
        _active = true;
    }

    public override void Deactivate()
    {
        _active = false;
    }

    void Update()
    {
        if (_active)
        {
            if (CanAct())
            {
                Act();
            }
        }

        Passive();
    }

    public abstract bool CanAct();
    public abstract void Act();
    public virtual void Passive() { }
}
