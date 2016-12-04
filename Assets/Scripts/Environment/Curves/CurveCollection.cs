using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class CurveCollection : Curve
{
	[HideInInspector]
    public List<Curve> curves;

    protected List<float> startingDistances;

	protected override void Init() {
	}

    void Start()
	{
		InitializeStartingLists();
		_length = CalculateLength();
    }

    private void InitializeStartingLists()
    {
        startingDistances = new List<float>();

        startingDistances.Add(0);
        for (int i = 0; i < curves.Count-1; i++)
        {
			startingDistances.Add(startingDistances[i] + curves[i].length);
        }
    }

    protected override float CalculateLength()
    {
        float result = 0.0f;
        foreach (Curve curve in curves)
            result += curve.length;
        return result;
    }

	protected override Vector3 PointAtPos(float x)
    {
        int i = BinarySearch(startingDistances, x);
        float x2 = x - startingDistances[i];
        return curves[i].PointAt(x2);
    }

    private int BinarySearch(List<float> list, float value)
    {
        int i = list.Count - 1;
        while (i > 0 && list[i] > value) i--;
        return i;
    }

//    protected override void DoOnValidate()
//    {
//        InitializeStartingLists();
//        base.DoOnValidate();
//    }

    public void Debuug()
    {
        Debug.Log("moi");
    }

}
