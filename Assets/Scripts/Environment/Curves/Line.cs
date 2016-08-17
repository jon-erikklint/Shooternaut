using UnityEngine;
using System.Collections;
using System;

public class Line : Curve {

    public GameObject startingPoint = new GameObject("StartingPoint");
    public GameObject endPoint = new GameObject("EndPoint");

    [HideInInspector] public Vector3 v0;
    [HideInInspector] public Vector3 v1;

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
        Debug.Log("PointAtStart");
        Debug.Log(v0);
        Debug.Log(v1);
        Debug.Log(Vector3.Lerp(v0, v1, x));
        Debug.Log("PointAtEnd");
        return Vector3.Lerp(v0, v1, x);
    }
}
