using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class MAIComponent : MonoBehaviour {

    protected ModularAI ai;

	public void Init(ModularAI ai)
    {
        this.ai = ai;

        WakeUp();
    }

    public virtual void WakeUp() { }

    public virtual void Act() { }
    public virtual void TurnOff() { }
    public virtual void TurnOn() { }
}
