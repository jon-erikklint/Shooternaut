using UnityEngine;
using System.Collections.Generic;

public abstract class Curve : MonoBehaviour {
    
	public bool isLoop;
    protected float _length;
	private float _unitLength;

	public float length { get { return _length; } }
	public float unitLength { get { return _unitLength; } }

    void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
		SetLength ();
    }

    public Vector3 PointAt(float x)
    {
        float pos = Mathf.Abs(length - x % (length * (isLoop ? 1 : 2)));
        return PointAtPos(pos);	
    }

    protected abstract Vector3 PointAtPos(float x);

	public virtual float XAtPoint(Vector3 position)
	{
		float minDist = (position - GlobalPointAt(0)).sqrMagnitude;
		float minI = 0;
		for (float i = 0.01f; i < length; i+= 0.01f) 
		{
			float dist = (position - GlobalPointAt(i)).sqrMagnitude;
			if (dist < minDist) 
			{
				minDist = dist;
				minI = i;
			}
		}
		Vector3 v0 = GlobalPointAt(minI);
		Vector3 v = GlobalPointAt (Mathf.Min(minI + 0.01f, length)) - v0;
		Vector3 x = position - v0;
		Vector3 proj = x - (Vector3.Dot (v, x) / v.sqrMagnitude * v);
		return minI + proj.magnitude;
	}

	public void SetLength()
	{
		_length = CalculateLength ();
	}

    public Vector3 GlobalPointAt(float x)
    {
        return PointAt(x) + transform.position;
    }

    protected abstract float CalculateLength();
}
