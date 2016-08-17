using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class CurveCollection : Curve
{
    
    public List<Curve> curves;

    private List<float> startingTimes;
    private List<float> startingDistances;

    protected override void Init() { }

    void Start()
    {
        InitializeStartingLists();
        _length = CalculateLength();
        _time = CalculateTime();
        print(_time + ", " + _length);
    }

    void InitializeStartingLists()
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
    }

    void Update()
    {
        MoveGameObjects(Time.deltaTime);
    }

    protected override float CalculateLength()
    {
        float result = 0.0f;
        foreach (Curve curve in curves)
        {
            print("len: " + curve.length);
            result += curve.length;
        }
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
        print(t + ", " + startingTimes[i] + ", " + curves[i].PointAtTime(t2));
        return curves[i].PointAtTime(t2);
    }

    private int BinarySearch(List<float> list, float value)
    {
        //int min = 0;
        //int max = list.Count;
        //int mid = 0;
        //while (min < max)
        //{
        //    mid = (min + max) / 2;
        //    if (list[mid] < value)
        //        min = mid;
        //    else max = mid;
        //}

        //return mid;
        int i = list.Count-1;
        while (i > 0 && list[i] > value)
        {

            i--;
        }
        print(i + ", " + list[i] + ", " + value);
        return i;
    }
}
