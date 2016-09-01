using UnityEngine;
using System.Collections;
using System;

public class Circle: Curve
{
    public float radius = 1;
    public float startingAngle = 0;
    public float endAngle = 360;

    protected override Vector3 PointAtPos(float x)
    {
        Quaternion rotator = Quaternion.AngleAxis((endAngle - startingAngle)*x + startingAngle, Vector3.forward);
        return rotator * (new Vector3(radius, 0, 0));
    }

    protected override float CalculateLength()
    {
        return (float)(2*radius*Math.PI*(endAngle-startingAngle)/360);
    }
}
