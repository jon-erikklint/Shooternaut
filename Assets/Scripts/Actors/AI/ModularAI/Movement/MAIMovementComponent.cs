using UnityEngine;
using System.Collections;
using System;

public abstract class MAIMovementComponent : MAIComponent {

    public float startDelay;

    private float startTime;

    protected Mover mover;

    public void Init(ModularAI ai, Mover mover)
    {
        this.mover = mover;

        base.Init(ai);
    }

    public override void WakeUp()
    {
        startTime = Time.time;
    }

    public override void Act()
    {
        if (Time.time > startTime + startDelay && WillMove())
        {
            Move();
        }
    }

    public abstract bool WillMove();
    public abstract Vector2 NextDirection();
    public abstract float NextMagnitude();

    protected void Move()
    {
        mover.Move(NextDirection(), NextMagnitude());
    }

    public override void TurnOn()
    {
        startTime = Time.time;
    }

}
