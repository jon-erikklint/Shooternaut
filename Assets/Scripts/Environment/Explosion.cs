using UnityEngine;
using System.Collections;
using System;

public class Explosion : Destroyable {

    public float maxDamage;

    public float radius = 3.0f;
    public float energy = 50.0f;
    public float duration = 0.5f;

    private float birth;

    private CircleCollider2D col;
    
	void Start () {
        col = gameObject.GetComponent<CircleCollider2D>();
        col.radius = 0;
        col.isTrigger = true;
        birth = Time.time;

        StartCoroutine("IncreaseRadius");
	}
	
    IEnumerator IncreaseRadius()
    {
        float deltaTime = Time.time - birth;
        while(deltaTime <= duration)
        {
            
            deltaTime = Time.time - birth;
            col.radius = radius * deltaTime / duration;
            yield return null;
        }

        Destroy(gameObject);
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

    public override void DestroySelf()
    {
        StopAllCoroutines();
        base.DestroySelf();
    }
}
