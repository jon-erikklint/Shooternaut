using UnityEngine;
using System.Collections;

public class Explosion : Projectile {

    public float radius = 3.0f;
    public float energy = 50.0f;
    public float duration = 0.5f;

    private float birth;

    private CircleCollider2D col;

	// Use this for initialization
	void Start () {
        col = gameObject.GetComponent<CircleCollider2D>();
        col.radius = 0;
        col.isTrigger = true;
        birth = Time.time;
	}
	
    void Update()
    {
        float deltaTime = Time.time - birth;
        col.radius = radius * deltaTime / duration;
        if(deltaTime > duration)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Vector3 displacement = other.transform.position - transform.position;
        other.GetComponent<Rigidbody2D>().AddForce(displacement/displacement.sqrMagnitude * energy/duration);
    }

}
