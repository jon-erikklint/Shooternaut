//using UnityEngine;
//using UnityEditor;
//using System.Collections.Generic;

//[CustomEditor(typeof(Polyline), true)]
//[CanEditMultipleObjects]
//public class PolyLineEditor : CurveCollectionEditor {

//    Polyline polyline;
//    List<Transform> wayPoints;
//    List<float> speeds;
//    List<float> rotations;
//    public bool editTransformList;
//    private bool prevLockValue;

//    protected override void DoOnEnable()
//    {
//        polyline = target as Polyline;
//        wayPoints = polyline.wayPoints;
//        speeds = polyline.speeds;
//        rotations = polyline.rotations;

//        if (wayPoints != null)
//        {
//            EditorHelper.RemoveNullReferences(wayPoints);
//            foreach (Transform trans in wayPoints)
//                trans.gameObject.SetActive(true);
//        }
//        if (speeds != null)
//        {
//            EditorHelper.RemoveNullReferences(speeds);
//            foreach (Transform trans in wayPoints)
//                trans.gameObject.SetActive(true);
//        }
//        if (rotations != null)
//        {
//            EditorHelper.RemoveNullReferences(rotations);
//            foreach (Transform trans in wayPoints)
//                trans.gameObject.SetActive(true);
//        }

//        base.DoOnEnable();
//    }

//    public override void OnInspectorGUI()
//    {
//        base.OnInspectorGUI();

//        if (wayPoints != null)
//            EditorHelper.RemoveNullReferences(wayPoints);
//        else
//        {
//            wayPoints = polyline.wayPoints;
//            return;
//        }
        
//        if (speeds != null)
//            EditorHelper.RemoveNullReferences(speeds);
//        else
//        {
//            speeds = polyline.speeds;
//            return;
//        }
        
//        if (rotations != null)
//            EditorHelper.RemoveNullReferences(rotations);
//        else
//        {
//            rotations = polyline.rotations;
//            return;
//        }

//        if (!editTransformList)
//        {
//            prevLockValue = ActiveEditorTracker.sharedTracker.isLocked;
//            if (GUILayout.Button("Add Transforms"))
//            {
//                editTransformList = true;
//                ActiveEditorTracker.sharedTracker.isLocked = true;
//            }
//        }
//        else
//        {
//            if (GUILayout.Button("Stop adding Transforms"))
//            {
//                editTransformList = false;
//                CreateLines();
//                ActiveEditorTracker.sharedTracker.isLocked = prevLockValue;
//            }
//        }

//        EditorHelper.MakeEqualLength(rotations, wayPoints, polyline.rotationDegrees);
//        EditorHelper.MakeEqualLength(speeds, wayPoints, polyline.startSpeed);
//    }

//    public void OnSceneGUI()
//    {
//        if (editTransformList)
//        {
//            Event e = Event.current;
//            Vector3 mousePos = MousePositionOnWorld(e);
//            if (e.type == EventType.MouseDown && e.button == 0)
//            {
//                foreach (Transform trans in wayPoints)
//                {
//                    if ((trans.position - mousePos).magnitude < 1)
//                    {
//                        return;
//                    }
//                }
//                GameObject newObject;
//                newObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//                newObject.name = "Waypoint " + wayPoints.Count;
//                newObject.transform.position = mousePos;
//                newObject.transform.parent = polyline.transform;

//                wayPoints.Add(newObject.transform);
//            }
//            //e.Use();
//        }
//    }

//    void OnDisable()
//    {
//        if (wayPoints != null)
//        {
//            foreach (Transform trans in wayPoints)
//                trans.gameObject.SetActive(false);
//        }
//        editTransformList = false;
//    }

//    protected Vector3 MousePositionOnWorld(Event e)
//    {
//        Vector3 mousePos = e.mousePosition;
//        mousePos = HandleUtility.GUIPointToWorldRay(mousePos).GetPoint(0);
//        mousePos.z = 0;
//        return mousePos;
//    }

//    protected void CreateLines()
//    {
//        polyline.curves = new List<Curve>();
//        for(int i = 0; i < wayPoints.Count - 1; i++)
//        {
//            Line line = new Line();
//            line.startingPoint = wayPoints[i].gameObject;
//            line.endPoint = wayPoints[i+1].gameObject;
//            line.startSpeed = speeds[i];
//            line.endSpeed = speeds[i+1];
//            line.rotationDegrees = rotations[i];
//            polyline.curves.Add(line);
//        }

//        if (polyline.isLoop)
//        {
//            int i = wayPoints.Count - 1;
//            Line line = new Line();
//            line.startingPoint = wayPoints[i].gameObject;
//            line.endPoint = wayPoints[0].gameObject;
//            line.startSpeed = speeds[i];
//            line.endSpeed = speeds[0];
//            line.rotationDegrees = rotations[i];
//            polyline.curves.Add(line);
//        }        
//    }

//}
