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
        SetGameObjectsAsChilds();
    }

    private void SetStartingPositions()
    {
        for(int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].transform.position = PointAt(gameObjectsPositions[i]);
        }
    }

    private void SetGameObjectsAsChilds()
    {
        foreach (GameObject obj in gameObjects)
        {
            Transform objParent = obj.transform.parent;
            if (objParent != null && objParent.gameObject != gameObject)
            {
                Debug.LogWarning(obj.name + " is already " + objParent.name + "'s child. It's parent is now changed to " + gameObject.name + ".");
                if (objParent.gameObject.GetComponent<Curve>() != null)
                    Debug.LogWarning(obj.name + " may already be moving in multiple curves.");
            }
            obj.transform.parent = this.transform;
        }
    }

    public virtual float XAtTime(float t)
    {
        return startSpeed * t + 0.5f * acceleration * t * t;
    }

    public abstract Vector3 PointAt(float x);

    private Vector3 GlobalPointAt(float x)
    {
        return PointAt(x) + transform.position;
    }

    public virtual Vector3 PointAtTime(float t)
    {
        return PointAt(XAtTime(t) / length);
    }

    private Vector3 GlobalPointAtTime(float t)
    {
        return PointAtTime(t) + transform.position;
    }

    public virtual Vector3 RotationVector(float x, float dt)
    {
        return new Vector3(0, 0, rotationDegrees * dt / time);
    }

    public Vector3 RotationVectorAtTime(float t, float dt)
    {
        return RotationVector(XAtTime(t), dt);
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
            
            gameObjectsPositions[i] = (currTime + dt) % (time * (isLoop ? 1 : 2));
            float t = gameObjectsPositions[i];
            t -= 2*(Mathf.Max(0, gameObjectsPositions[i] - time));

            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

            if(rb == null)
            {
                obj.transform.position = GlobalPointAtTime(t);                
                obj.transform.Rotate(RotationVectorAtTime(t, dt));
            }
            else
            {
                rb.velocity = (GlobalPointAtTime(t) - obj.transform.position).normalized*SpeedAtTime(t) * (t < time ? 1 : -1);
                if (!rotatesFreely)
                    rb.angularVelocity = RotationVectorAtTime(t, dt).z;
            }

        }
    }

    protected abstract float CalculateLength();

    protected virtual float CalculateTime()
    {
        return 2 * length / (startSpeed + endSpeed);
    }

    public virtual bool OutOfRange(float t)
    {
        return t > time * (isLoop ? 1 : 2);
    }

}
