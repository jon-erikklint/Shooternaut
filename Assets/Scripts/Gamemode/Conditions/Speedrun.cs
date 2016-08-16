using UnityEngine;
using System.Collections;
using System;

public class Speedrun : MonoBehaviour, Condition
{
    public float TimeLimit;

    private float startTime;
    private float? endTime;

    public string Name()
    {
        return "Gotta go fast!";
    }

    public string Description()
    {
        return "Complete other objectives before time runs out!";
    }

    public void Begin()
    {
        startTime = Time.time;
        endTime = null;
    }

    public void End()
    {
        endTime = Time.time;
    }

    public bool Lost()
    {
        return TimeLeft() < 0;
    }

    public float TimeLeft()
    {
        if(endTime != null)
        {
            return TimeLimit - (float) endTime + startTime;
        }

        return TimeLimit - Time.time + startTime;
    }
}
