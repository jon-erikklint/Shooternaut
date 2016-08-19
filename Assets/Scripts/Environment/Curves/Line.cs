using UnityEngine;
using System.Collections;
using System;

public class Line : Curve {

    public GameObject startingPoint;
    public GameObject endPoint;

    [HideInInspector] public Vector3 v0 { get { return startingPoint.transform.position; } }
    [HideInInspector] public Vector3 v1 { get { return endPoint.transform.position; } }

    void Awake()
    {
        Init();
    }

    void Update()
    {
        MoveGameObjects(Time.deltaTime);
    }

    protected override float CalculateLength()
    {
        return (v0 - v1).magnitude;
    }

    public override Vector3 PointAt(float x)
    {
        return Vector3.Lerp(v0, v1, x);
    }
}
