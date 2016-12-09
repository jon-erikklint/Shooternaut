using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class ClickingActivateable : Activateable{

    private bool acting = false;

    void Update()
    {
        if (active)
        {
            if (CanAct())
            {
                acting = true;
                Act();
            }else if (acting)
            {
                CantActAnymore();
            }
        }

        Passive();
    }

    public abstract bool CanAct();
    public abstract void Act();
    public abstract void CantActAnymore();

    public virtual void Passive() { }
}
