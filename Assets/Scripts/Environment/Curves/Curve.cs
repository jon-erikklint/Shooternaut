using UnityEngine;
using System.Collections.Generic;

public abstract class Curve : MonoBehaviour {
    public float startSpeed;
    public float endSpeed;
    public float rotationDegrees;
    public float length { get { return _length; } }
    private float _length;

    public List<GameObject> gameObjects;
    public abstract float CalculateLength();
    private void SetLength()
    {
        if (_length == null) _length = CalculateLength();
    }
    public abstract Vector3 PointAt(float t);
}
