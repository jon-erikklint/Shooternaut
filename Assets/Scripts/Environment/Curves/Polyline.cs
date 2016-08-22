using UnityEngine;
using System.Collections.Generic;

public class Polyline : CurveCollection {

    public List<Transform> wayPoints;
    public List<float> speeds;
    public List<float> rotations;

    protected override void Init()
    {
        for(int i = 0; i < wayPoints.Count-1; i++)
        {
            Line line = new Line();
        }
        base.Init();
    }

}
