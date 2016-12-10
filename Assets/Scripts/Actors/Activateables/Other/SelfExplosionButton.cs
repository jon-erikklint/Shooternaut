using UnityEngine;
using System.Collections;
using System;

public class SelfExplosionButton : Activateable
{
    public GameObject explosion;
    public float delay;

    private float startTime;

    public override void Activate()
    {
        if (!active)
        {
            startTime = Time.time;
        }

        base.Activate();
    }

    void Update()
    {
        if(active && Time.time > startTime + delay)
        {
            Explode();
        }
    }

    public void Explode()
    {
        GameObject go = (GameObject) Instantiate(explosion);

        Vector3 location = owner.transform.position;
        location.z = go.transform.position.z;
        go.transform.position = location;

        owner.Destroy();
    }

    public override bool CanActivate()
    {
        return true;
    }

    public override bool FullActivate()
    {
        return true;
    }

    public override ActivateableType Type()
    {
        return ActivateableType.Button;
    }
}
