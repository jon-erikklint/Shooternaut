using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class CurveCollection : Curve
{
    
    public List<Curve> curves;

    protected List<float> startingTimes;
    protected List<float> startingDistances;

    protected override void Init() { }

    void Start()
    {
        InitializeStartingLists();
        _length = CalculateLength();
        _time = CalculateTime();
    }

    private void InitializeStartingLists()
    {
        startingTimes = new List<float>();
        startingDistances = new List<float>();

        startingTimes.Add(0);
        startingDistances.Add(0);
        for(int i = 0; i < curves.Count-1; i++)
        {
            startingTimes.Add(startingTimes[i] + curves[i].time);
            startingDistances.Add(startingDistances[i] + curves[i].length);
        }
        SetGameObjectsAsChilds();
    }

    void Update()
    {
        MoveGameObjects(Time.deltaTime);
    }

    protected override float CalculateLength()
    {
        float result = 0.0f;
        foreach (Curve curve in curves)
            result += curve.length;
        return result;
    }

    protected override float CalculateTime()
    {
        float result = 0.0f;
        foreach (Curve curve in curves)
            result += curve.time;
        return result;
    }

    public override Vector3 PointAt(float x)
    {
        int i = BinarySearch(startingDistances, x);
        float x2 = x - startingDistances[i];
        return curves[i].PointAt(x2);
    }

    public override Vector3 PointAtTime(float t)
    {
        int i = BinarySearch(startingTimes, t);
        float t2 = t - startingTimes[i];
        return curves[i].PointAtTime(t2);
    }

    public override float XAtTime(float t)
    {
        int i = BinarySearch(startingTimes, t);
        return startingDistances[i] + curves[i].XAtTime(t - startingTimes[i]);
    }

    public override Vector3 RotationVector(float x, float dt)
    {
        int i = BinarySearch(startingDistances, x);
        return curves[i].RotationVector(x, dt);
    }

    private int BinarySearch(List<float> list, float value)
    {
        int i = list.Count-1;
        while (i > 0 && list[i] > value) i--;
        return i;
    }

    protected override void DoOnValidate()
    {
        InitializeStartingLists();
        base.DoOnValidate();
    }

}
