using UnityEngine;
using System.Collections;
using System;

public class Circle: Curve
{
    public float radius = 1;
    public float startingAngle = 0;
    public float endAngle = 360;

    void Update()
    {
        MoveGameObjects(Time.deltaTime);
    }

    public override Vector3 PointAt(float x)
    {
        Quaternion rotator = Quaternion.AngleAxis((endAngle - startingAngle)*x, Vector3.forward);
        return rotator * (new Vector3(radius, 0, 0));
    }

    protected override float CalculateLength()
    {
        return (float)(2*Math.PI*(endAngle-startingAngle)/360);
    }
}
