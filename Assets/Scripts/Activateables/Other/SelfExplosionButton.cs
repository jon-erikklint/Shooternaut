using UnityEngine;
using System.Collections;
using System;

public class SelfExplosionButton : Activateable
{
    public GameObject explosion;
    public float delay;

    private float startTime;

    private bool setUp = false;

    public override void Activate()
    {
        if (!setUp)
        {
            setUp = true;
            startTime = Time.time;
        }
    }

    public override void Deactivate()
    {
        setUp = false;
    }

    void Update()
    {
        if(setUp && Time.time > startTime + delay)
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

        owner.DestroySelf();
    }

    public override bool CanActivate()
    {
        return true;
    }

    public override bool FullActivate()
    {
        return true;
    }

    public override void Reset()
    {
        setUp = false;
    }

    public override ActivateableType Type()
    {
        return ActivateableType.Button;
    }

    public override GameObject UIElement()
    {
        return null;
    }
}
