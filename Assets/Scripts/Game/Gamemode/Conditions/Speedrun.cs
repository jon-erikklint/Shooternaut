using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Speedrun : Condition
{
    public float TimeLimit;

    private float? startTime;
    private float? endTime;

    public override string Name()
    {
        return "Gotta go fast!";
    }

    public override string Description()
    {
        return "Complete other objectives before time runs out!";
    }

    public override void Begin()
    {
        startTime = Time.time;
        endTime = null;
    }

    public override void End()
    {
        endTime = Time.time;
    }

    public override bool Lost()
    {
        return TimeLeft() < 0;
    }

    public float TimeLeft()
    {
        if(startTime == null)
        {
            return TimeLimit;
        }

        if(endTime != null)
        {
            return TimeLimit - (float) endTime + (float) startTime;
        }

        return TimeLimit - Time.time + (float) startTime;
    }

    public override void initialize(GameObject uiElement)
    {
        uiElement.GetComponentInChildren<SpeedrunClock>().speedrun = this;
    }

    public override List<object> RespawnPointReached(RespawnPoint respawn)
    {
        return new List<object>();
    }

    public override bool Respawn(List<object> lastState){ return true; }

    public override void DestroySelf(){}
}
