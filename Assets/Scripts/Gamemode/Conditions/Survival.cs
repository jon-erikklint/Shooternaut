using UnityEngine;
using System.Collections;
using System;

public class Survival : MonoBehaviour, Condition
{
    public int lives;

    public string Name()
    {
        return "Survive to the end!";
    }

    public string Description()
    {
        return "Survive to the end without losing all of your " + lives + " lives.";
    }

    public bool Lost()
    {
        return lives <= 0;
    }

    public void End(){}

    public void Begin(){}

    void Start()
    {
        RespawnManager rm = FindObjectOfType<RespawnManager>();
        rm.survival = this;
    }
}
