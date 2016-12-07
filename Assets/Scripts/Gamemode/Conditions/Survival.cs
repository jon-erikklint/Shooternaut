using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Survival : Condition
{
    public int lives;

    public override string Name()
    {
        return "Survive to the end!";
    }

    public override string Description()
    {
        return "Survive to the end without losing all of your " + lives + " lives.";
    }

    public override bool Lost()
    {
        return lives <= 0;
    }

    public override void End(){}

    public override void Begin(){}

    public override void initialize(GameObject uiElement)
    {
        FindObjectOfType<RespawnManager>().survival = this;
        uiElement.GetComponentInChildren<SurvivalLives>().survival = this;
    }

    public override List<object> RespawnPointReached(RespawnPoint respawn)
    {
        return new List<object>();
    }

    public override bool Respawn(List<object> lastState)
    {
        lives--;

        return true;
    }

    public override void DestroySelf(){}
}
