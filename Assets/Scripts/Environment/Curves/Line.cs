using UnityEngine;
using System.Collections;
using System;

public class Line : Curve
{

    public Transform startingPoint;
    public Transform endPoint;

    [HideInInspector]
    public Vector3 v0 { get { return startingPoint.localPosition; } }
    [HideInInspector]
    public Vector3 v1 { get { return endPoint.localPosition; } }

    void Awake()
    {
        Init();
    }

    protected override float CalculateLength()
    {
        return (v0 - v1).magnitude;
    }

    protected override Vector3 PointAtPos(float x)
    {
        return Vector3.Lerp(v0, v1, x/length);
    }
}
