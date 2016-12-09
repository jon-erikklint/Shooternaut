using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Explosion : Respawnable {

    public float damagePerSecond;

    public float maxRadius;
    public float minRadius;

    public float maxEnergy;
    public float minEnergy;

    public float maxEnergyRadius;
    public float minEnergyRadius;

    public float duration;

    private float currentRadius;
    private float currentRadiusMultiplier;

    private float birth;
    
	public override void Init () {
        birth = Time.time;
        currentRadius = minRadius;
        currentRadiusMultiplier = currentRadius / maxRadius;
	}
	
    void Update()
    {
        if(Time.time > birth + duration)
        {
            DestroySelf();
            return;
        }

        currentRadius = ((maxRadius - minRadius) * (Time.time-birth) / duration) + minRadius;
        currentRadiusMultiplier = currentRadius / maxRadius;

        transform.localScale = new Vector3(currentRadius, currentRadius);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Vector3 displacement = other.transform.position - transform.position;
        float distance = displacement.magnitude;

        float energy = minEnergy*currentRadiusMultiplier;
        if(distance < maxEnergyRadius*currentRadiusMultiplier)
        {
            energy = maxEnergy;
        }else if(distance < minEnergyRadius*currentRadiusMultiplier)
        {
            energy += (maxEnergy - minEnergy) * (minEnergyRadius*currentRadiusMultiplier - distance)/(currentRadiusMultiplier * (minEnergyRadius- maxEnergyRadius));
        }

        other.GetComponent<Rigidbody2D>().AddForce(displacement.normalized * energy/duration);

        DoDamage(other.GetComponent<Actor>());
    }

    private void DoDamage(Actor actor)
    {
        if(actor == null)
        {
            return;
        }

        float damageDealt = damagePerSecond * Time.deltaTime;

        actor.LoseHealth(damageDealt);
    }

    public override List<object> RespawnPointReached(RespawnPoint respawn)
    {
        return new List<object>();
    }

    public override bool Respawn(List<object> lastState)
    {
        DestroySelf();

        return false;
    }
}
