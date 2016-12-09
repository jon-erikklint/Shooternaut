using UnityEngine;
using System.Collections;

public abstract class MAIActivateableComponent : MAIComponent {

    public float activationDelay;

    private float startTime;

    protected Activateable activateable;

    public void Init(ModularAI mai, Activateable activateable)
    {
        this.activateable = activateable;

        base.Init(mai);
    }

    public override void WakeUp()
    {
        startTime = Time.time;
    }

    public override void Act()
    {
        if(Time.time > startTime + activationDelay)
        {
            activateable.SetActive(NextState());
        }
    }

    public abstract bool NextState();

    public override void TurnOff()
    {
        activateable.Deactivate();
    }

    public override void TurnOn()
    {
        startTime = Time.time;
    }
}
