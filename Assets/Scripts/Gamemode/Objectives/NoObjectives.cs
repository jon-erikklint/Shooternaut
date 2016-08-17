using UnityEngine;
using System.Collections;
using System;

public class NoObjectives : MonoBehaviour, Objective
{
    public bool Achieved()
    {
        return false;
    }

    public void Begin(){}

    public string Name()
    {
        return "No objectives";
    }

    public string Description()
    {
        return "No objectives";
    }
}
