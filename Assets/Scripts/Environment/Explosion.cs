using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Explosion : Destroyable, Respawnable {

    public float maxDamage;

    public float radius = 3.0f;
    public float energy = 50.0f;
    public float duration = 0.5f;

    private float birth;
    
	void Start () {
        birth = Time.time;
	}
	
    void Update()
    {
        if(Time.time > birth + duration)
        {
            DestroySelf();
            return;
        }

        float currentRadius = radius * (Time.time-birth) / duration;
        transform.localScale = new Vector3(currentRadius, currentRadius);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Vector3 displacement = other.transform.position - transform.position;
        other.GetComponent<Rigidbody2D>().AddForce(displacement/displacement.sqrMagnitude * energy/duration);

        DoDamage(other.GetComponent<Actor>());
    }

    private void DoDamage(Actor actor)
    {
        if(actor == null)
        {
            return;
        }

        float damageDealt = maxDamage * (Time.deltaTime/duration);

        actor.LoseHealth(damageDealt);
    }

    public List<object> RespawnPointReached(RespawnPoint respawn)
    {
        return new List<object>();
    }

    public void Respawn(List<object> lastState)
    {
        DestroySelf();
    }
}
