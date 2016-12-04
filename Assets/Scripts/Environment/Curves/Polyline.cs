
using System.Collections.Generic;
using UnityEngine;

public class Polyline : CurveCollection {

	public GameObject prefab;
    public List<Transform> wayPoints;
    public List<float> speeds;
    public List<float> rotations;

    protected override void Init()
    {
		for(int i = 0; i < wayPoints.Count - 1 ; i++)
        
			AddLine (wayPoints [i+1], wayPoints [i]);
        
		if (isLoop) 
			AddLine(wayPoints[0], wayPoints[wayPoints.Count-1]);
		
        base.Init();
    }
	private void AddLine(Transform start, Transform end)
	{
		GameObject gameObject = Instantiate (prefab);
		Line line = gameObject.GetComponent<Line> ();
		line.startingPoint = start;
		line.endPoint = end;
		line.SetLength ();
		curves.Add (line);
	}
}
