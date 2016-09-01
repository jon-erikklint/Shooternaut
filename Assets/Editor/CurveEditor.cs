//using UnityEngine;
//using UnityEditor;
//using System.Collections.Generic;

//[CustomEditor(typeof(Curve), true)]
//[CanEditMultipleObjects]
//public class CurveEditor : Editor
//{

//    protected Curve curve;
//    protected List<GameObject> gameObjects;
//    protected List<float> gameObjectsPositions;

//    void OnEnable()
//    {
//        DoOnEnable();
//    }

//    protected virtual void DoOnEnable()
//    {
//        curve = target as Curve;
//        gameObjects = curve.gameObjects;
//        gameObjectsPositions = curve.gameObjectsPositions;
//    }

//    public override void OnInspectorGUI()
//    {
//        if(gameObjects != null)
//        {
//            EditorHelper.RemoveNullReferences(gameObjects);
//            EditorHelper.MakeEqualLength(gameObjectsPositions, gameObjects, 0);
//        }
//        if (GUILayout.Button("Update"))
//        {
//            DoOnUpdate();
//        }

//        base.OnInspectorGUI();
//    }

//    protected virtual void DoOnUpdate()
//    {
//        SetGameObjectsAsChild();
//        SetGameObjectsToTheirPositions();
//    }

//    protected virtual void SetGameObjectsAsChild()
//    {
//        foreach (GameObject obj in gameObjects)
//            obj.transform.parent = curve.transform;
//    }

//    protected virtual void SetGameObjectsToTheirPositions()
//    {
//        for (int i = 0; i < gameObjects.Count; i++)
//        {
//            GameObject obj = gameObjects[i];
//            float x = gameObjectsPositions[i];
//            obj.transform.localPosition = curve.PointAt(x);
//        }
//    }

//}
