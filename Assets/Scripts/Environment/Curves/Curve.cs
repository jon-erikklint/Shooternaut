using UnityEngine;
using System.Collections.Generic;

public abstract class Curve : MonoBehaviour {
    public float startSpeed;
    public float endSpeed;
    public float rotationDegrees;
    public float length { get { return _length; } }
    private float _length = 0.0f;

    public List<GameObject> gameObjects;
    public abstract float CalculateLength();
    private void SetLength()
    {
        if (_length == 0.0f) _length = CalculateLength();
    }
    public abstract Vector3 PointAt(float t);
}
