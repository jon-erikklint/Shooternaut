using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(WayPointCurve), true)]
public class WayPointCurveEditor : CurveEditor
{
    private List<Transform> wayPoints;
    private WayPointCurve wayPointCurve;
    public bool editTransformList;
    private bool prevLockValue;

    void OnEnable()
    {
        wayPointCurve = target as WayPointCurve;
        wayPoints = wayPointCurve.wayPoints;
        if(wayPoints != null)
        {
        foreach (Transform trans in wayPoints)
            trans.gameObject.SetActive(true);
        }
    }

    void OnDisable()
    {
        if(wayPoints != null)
        {
        foreach (Transform trans in wayPoints)
            trans.gameObject.SetActive(false);
        }
        editTransformList = false;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (wayPoints != null)
            EditorHelper.RemoveNullReferences(wayPoints);
        else
        {
            wayPoints = wayPointCurve.wayPoints;
            return;
        }
        if (!editTransformList)
        {
            prevLockValue = ActiveEditorTracker.sharedTracker.isLocked;
            if (GUILayout.Button("Add Transforms"))
            {
                editTransformList = true;
                ActiveEditorTracker.sharedTracker.isLocked = true;
            }
        }
        else
        {
            if (GUILayout.Button("Stop adding Transforms"))
            {
                editTransformList = false;
                ActiveEditorTracker.sharedTracker.isLocked = prevLockValue;
            }
        }
    }

    public void OnSceneGUI()
    {
        if (editTransformList)
        {
            Event e = Event.current;
            Vector3 mousePos = MousePositionOnWorld(e);
            if (e.type == EventType.MouseDown && e.button == 0)
            {
                foreach(Transform trans in wayPoints)
                {
                    if((trans.position - mousePos).magnitude < 1)
                    {
                        return;
                    }
                }
                GameObject newObject;
                newObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                newObject.name = "Waypoint " + wayPoints.Count;
                newObject.transform.position = mousePos;
                newObject.transform.parent = wayPointCurve.transform;

                wayPoints.Add(newObject.transform);
            }
            //e.Use();
        }
    }

    protected Vector3 MousePositionOnWorld(Event e)
    {
        Vector3 mousePos = e.mousePosition;
        mousePos = HandleUtility.GUIPointToWorldRay(mousePos).GetPoint(0);
        mousePos.z = 0;
        return mousePos;
    }

}
