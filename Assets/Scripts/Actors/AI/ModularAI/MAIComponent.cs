using UnityEngine;
using System.Collections;

public abstract class MAIComponent : MonoBehaviour {

    protected ModularAI ai;

	public void Init(ModularAI ai)
    {
        this.ai = ai;

        WakeUp();
    }

    public virtual void WakeUp() { }
    public virtual void Act() { }
}
