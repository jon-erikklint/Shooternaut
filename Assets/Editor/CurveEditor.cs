using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(Curve), true)]
public class CurveEditor : Editor
{

    Curve curve;
    List<GameObject> gameObjects;
    List<float> gameObjectsPositions;

    void OnEnable()
    {
        DoOnEnable();
    }

    protected void DoOnEnable()
    {
        curve = target as Curve;
        gameObjects = curve.gameObjects;
        gameObjectsPositions = curve.gameObjectsPositions;
    }

    public override void OnInspectorGUI()
    {
        EditorHelper.RemoveNullReferences(gameObjects);
        EditorHelper.MakeEqualLength(gameObjectsPositions, gameObjects, 0);
        if (GUILayout.Button("Update"))
        {
            SetGameObjectsAsChild();
            SetGameObjectsToTheirPositions();
        }
        base.OnInspectorGUI();
    }

    void SetGameObjectsAsChild()
    {
        foreach (GameObject obj in gameObjects)
            obj.transform.parent = curve.transform;
    }

    void SetGameObjectsToTheirPositions()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            GameObject obj = gameObjects[i];
            float x = gameObjectsPositions[i];
            Debug.Log(curve.PointAt(x));
            obj.transform.localPosition = curve.PointAt(x);
        }
    }

}
