using UnityEngine;
using System.Collections;
using System;

public class Turn : Mover
{
    private Transform ot;

    protected override void Init()
    {
        ot = owner.transform;
    }

    public override void Move(Vector2 direction, float magnitude)
    {
        ot.Rotate(new Vector3(0, 0, magnitude));
    }
}
