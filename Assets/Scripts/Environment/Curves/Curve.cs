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

    protected float _length;
    protected float _time;
    protected float _acceleration;
    
    public abstract Vector3 PointAt(float x);
    protected abstract float CalculateLength();

    void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        _length = CalculateLength();
        _time = CalculateTime();
        _acceleration = (endSpeed * endSpeed - startSpeed * startSpeed) / (2 * length);
    }

    public virtual Vector3 PointAtTime(float t)
    {
        float x = startSpeed * t + 0.5f * acceleration * t * t;
        if(x > length)
        {
            Debug.Log(acceleration);
        }
        return PointAt(x / length);
    }

    public virtual void MoveGameObjects(float dt)
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjectsPositions[i] = (gameObjectsPositions[i] + dt) % (time * (isLoop ? 1 : 2));
            float t = gameObjectsPositions[i];
            t -= 2*(Mathf.Max(0, gameObjectsPositions[i] - time));
            gameObjects[i].transform.position = PointAtTime(t);
            gameObjects[i].transform.Rotate(new Vector3(0, 0, rotationDegrees * dt / time));
        }
    }

    protected virtual float CalculateTime()
    {
        return 2 * length / (startSpeed + endSpeed);
    }

    public virtual bool OutOfRange(float t)
    {
        return t > time * (isLoop ? 1 : 2);
    }

}
