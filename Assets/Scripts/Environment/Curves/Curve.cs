using UnityEngine;
using System.Collections.Generic;

public abstract class Curve : MonoBehaviour {
    public bool isLoop;
    public bool rotatesFreely;
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
    [HideInInspector]
    public float angularVelocity { get { return _angularVelocity; } }

    protected float _length;
    protected float _time;
    protected float _acceleration;
    protected float _angularVelocity;
    
    public abstract Vector3 PointAt(float x);
    protected abstract float CalculateLength();

    void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        _length = CalculateLength();
        _acceleration = (endSpeed * endSpeed - startSpeed * startSpeed) / (2 * length);
        _time = CalculateTime();
        _angularVelocity = rotationDegrees / time;
        SetStartingPositions();

    }

    private void SetStartingPositions()
    {
        for(int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].transform.position = PointAt(gameObjectsPositions[i]);
        }
    }

    public virtual Vector3 PointAtTime(float t)
    {
        float x = startSpeed * t + 0.5f * acceleration * t * t;
        return PointAt(x / length);
    }

    public virtual float SpeedAtTime(float t)
    {
        return startSpeed + acceleration * t;
    }

    public virtual void MoveGameObjects(float dt)
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            GameObject obj = gameObjects[i];
            float currTime = gameObjectsPositions[i];

            //obj.transform.position = PointAt(currTime);
            gameObjectsPositions[i] = (currTime + dt) % (time * (isLoop ? 1 : 2));
            float t = gameObjectsPositions[i];
            t -= 2*(Mathf.Max(0, gameObjectsPositions[i] - time));

            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

            if(rb == null)
            {
                obj.transform.position = PointAtTime(t);
                obj.transform.Rotate(new Vector3(0, 0, rotationDegrees * dt / time));
            }
            else
            {
                rb.velocity = (PointAtTime(t) - obj.transform.position).normalized*SpeedAtTime(t) * (t < time ? 1 : -1);
                if (!rotatesFreely)
                    rb.angularVelocity = angularVelocity;

            }

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
