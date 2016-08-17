using UnityEngine;
using System.Collections.Generic;

public abstract class Curve : MonoBehaviour {
    public bool isLoop;
    public float startSpeed;
    public float endSpeed;
    public float rotationDegrees;
    public List<GameObject> gameObjects;
    public List<float> gameObjectsPositions;

    [HideInInspector]
    public float length { get { return _length; } }
    [HideInInspector]
    public float time { get { return _time; } }
    [HideInInspector]
    public float acceleration { get { return _acceleration; } }

    private float _length;
    private float _time;
    private float _acceleration;
    
    public abstract Vector3 PointAt(float x);
    protected abstract float CalculateLength();

    void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        _length = CalculateLength();
        _time = (startSpeed + endSpeed) * length / 2;
        _acceleration = 2 * (endSpeed - startSpeed) / (length * (endSpeed + startSpeed));
    }

    protected virtual Vector3 PointAtTime(float t)
    {
        float x = startSpeed * time + 0.5f * acceleration * time * time;
        return PointAt(x);
    }

    public virtual void MoveGameObjects(float dt)
    {
        for(int i = 0; i < gameObjects.Count; i++)
        {
            gameObjectsPositions[i] += dt % time*(isLoop ? 1 : 2);
            float t = gameObjectsPositions[i] / time;
            if (!isLoop) t -= (Mathf.Max(0, gameObjectsPositions[i]/time - 1));
            gameObjects[i].transform.position = PointAtTime(t);
            gameObjects[i].transform.Rotate(new Vector3(rotationDegrees*dt/time, 0, 0));
        }
    }

    public virtual bool OutOfRange(float t)
    {
        return t > time * (isLoop ? 1 : 2);
    }

}
