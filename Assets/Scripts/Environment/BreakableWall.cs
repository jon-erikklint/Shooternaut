using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BreakableWall : Respawnable
{
    public float momentumBreakLimit;

    public bool saveStateOverRespawn;
    
    public bool broken { get { return _broken; } }
    private bool _broken;

    public float alphaResetTime = 2;
    private float colorMultiplier;

    private Color rendColor;
    private Material rendMaterial;

    public override void Init()
    {
        _broken = false;
        colorMultiplier = 1;

        rendMaterial = GetComponent<Renderer>().material;
        rendColor = rendMaterial.color;
    }

    void Update()
    {
        if(colorMultiplier < 1)
        {
            colorMultiplier = Math.Min(1, colorMultiplier + Time.deltaTime / alphaResetTime);

            Color color = new Color(RightColor(rendColor.r), RightColor(rendColor.g), RightColor(rendColor.b));

            rendMaterial.color = color;
        }
    }

    private float RightColor(float channel)
    {
        return channel + ((1 - channel) * (1 - colorMultiplier));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        float momentum = col.rigidbody.velocity.magnitude * col.rigidbody.mass;

        if(momentum >= momentumBreakLimit)
        {
            Break();
        }
        else
        {
            colorMultiplier = 1 - momentum / momentumBreakLimit;
        }
    }

    public void Break()
    {
        _broken = true;
        gameObject.SetActive(false);
    }

    public void Fix()
    {
        _broken = false;
        gameObject.SetActive(true);
    }

    public override bool Respawn(List<object> lastState)
    {
        if (!saveStateOverRespawn)
        {
            Fix();
        }

        colorMultiplier = 1;
        rendMaterial.color = rendColor;

        return true;
    }

    public override List<object> RespawnPointReached(RespawnPoint respawn)
    {
        return new List<object>();
    }
}
