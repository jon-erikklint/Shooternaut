using UnityEngine;
using System.Collections;
using System;

public class Line : Curve {

    public GameObject startingPoint;
    public GameObject endPoint;

    [HideInInspector] public Vector3 v0;
    [HideInInspector] public Vector3 v1;

    void Awake()
    {
        Init();
    }

    void Update()
    {
        MoveGameObjects(Time.deltaTime);
    }

    protected override void Init()
    {
        v0 = startingPoint.transform.position;
        v1 = endPoint.transform.position;

        Destroy(startingPoint.gameObject);
        Destroy(endPoint.gameObject);

        base.Init();
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
