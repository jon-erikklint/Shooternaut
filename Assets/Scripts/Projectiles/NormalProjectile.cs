using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class NormalProjectile : Projectile
{
    public int damage;
    public List<string> destroyerTags;

    public HashSet<string> tagsThatDestroyThis;

    void Start()
    {
        initialize(destroyerTags);
    }

    public void initialize(List<string> tags)
    {
        tagsThatDestroyThis = new HashSet<string>();

        foreach (string tag in tags)
        {
            tagsThatDestroyThis.Add(tag);
        }
    }

    public override int Damage()
    {
        return damage;
    }

    public override bool GetsDestroyed(string colliderTag)
    {
        return tagsThatDestroyThis.Contains(colliderTag);
    }

    public override void OnHit(){}

    public override void OnDestruction(){}
}
