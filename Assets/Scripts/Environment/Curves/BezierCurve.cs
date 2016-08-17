using UnityEngine;
using System.Collections.Generic;
using System;

public class BezierCurve: WayPointCurve {

    float len;
    float t = 0;
    public GameObject pallo;

    public void Start()
    {
        len = LengthOfCurve();
    }

    void Update()
    {
        t = (t + Time.deltaTime) % 1;
        pallo.transform.position = PointAt(t);
    }

    protected override float CalculateLength()
    {
        return len;
    }

    public override Vector3 PointAt(float t)
    {
        Vector3[] vectorList = new Vector3[wayPoints.Count];
        for (int i = 0; i < wayPoints.Count; i++)
        {
            vectorList[i] = (wayPoints[i].position);
        }
        return PointAtHelper(t, vectorList)[0];
    }

    private Vector3[] PointAtHelper(float t, Vector3[] wayPoints)
    {
        int numOfPoints = wayPoints.Length;
        if (numOfPoints > 1)
        {
            Vector3[] newWayPoints = new Vector3[numOfPoints - 1];
            for (int i = 0; i < numOfPoints-1; i++)
            {
                newWayPoints[i] = Vector3.Lerp(wayPoints[i], wayPoints[i + 1], t);
            }
            return PointAtHelper(t, newWayPoints);
        }
        else
            return wayPoints;
    }

    private float LengthOfCurve()
    {
        return 0.0f;
    }

}
