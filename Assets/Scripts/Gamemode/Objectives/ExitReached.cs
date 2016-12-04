using UnityEngine;
using System.Collections;
using System;

public class ExitReached : MonoBehaviour, Objective
{
    private bool endreached;

    public void ReacheEnd()
    {
        Debug.Log("DSF");
        endreached = true;
    }

    public string Name()
    {
        return "Reach the exit!";
    }

    public string Description()
    {
        return "Get to tha exxaatth!!";
    }

    public bool Achieved()
    {
        return endreached;
    }

    public void Begin()
    {
        endreached = false;

        Exit[] exits = FindObjectsOfType<Exit>();

        foreach(Exit exit in exits)
        {
            exit.exitReached.AddListener(this.ReacheEnd);
        }
    }
}
