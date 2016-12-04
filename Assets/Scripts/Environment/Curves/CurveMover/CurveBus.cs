using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public abstract class CurveBus : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public List<float> gameObjectsPositions;
    [HideInInspector]
    public Curve curve;

   void Start () {
        curve = gameObject.GetComponent<Curve>();
		if (curve == null) {
			Debug.LogWarning ( name + " does not have any curve attatched to it!" );
			gameObjects.Clear ();
		}
        SetGameObjectsToTheirPositions();
    }
    
    protected void SetGameObjectsToTheirPositions()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
			Debug.Log ("huoh... " + gameObjectsPositions [i] + " " + curve.PointAt(gameObjectsPositions[i]));
            gameObjects[i].transform.localPosition = curve.PointAt(gameObjectsPositions[i]);
        }
    }

    /****************
     * Editor stuff *
     ****************/

    protected void SetGameObjectsAsChilds()
    {
        foreach (GameObject obj in gameObjects)
        {
            Transform objParent = obj.transform.parent;
            if (objParent != null && objParent.gameObject != gameObject)
            {
                Debug.LogWarning(obj.name + " is already " + objParent.name + "'s child. It's parent is now changed to " + gameObject.name + ".");
                if (objParent.gameObject.GetComponent<CurveBus>() != null)
                    Debug.LogWarning(obj.name + " may already be moving in multiple curves.");
            }
            obj.transform.parent = transform;
        }
    }

	public Vector3 GlobalPointAt(float x)
	{
		return curve.GlobalPointAt (x);
	}

	public Vector3 PointAt(float x)
	{
		return curve.PointAt (x);
	}

	public float XAtPoint(Vector3 position)
	{
		return curve.XAtPoint (position);
	}

    void OnValidate()
    {
        //DoOnValidate();
    }

    protected virtual void DoOnValidate()
    {
        SetGameObjectsAsChilds();
        SetGameObjectsToTheirPositions();
    }

}
