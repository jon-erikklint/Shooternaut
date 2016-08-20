using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(WayPointCurve), true)]
public class WayPointCurveEditor : Editor
{
    private List<Transform> wayPoints;
    private WayPointCurve wayPointCurve;

    void OnEnable()
    {
        wayPointCurve = target as WayPointCurve;
        wayPoints = wayPointCurve.wayPoints;
        foreach (Transform trans in wayPoints)
            trans.gameObject.SetActive(true);
    }

    void OnDisable()
    {
        foreach (Transform trans in wayPoints)
            trans.gameObject.SetActive(false);
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("Edit transform list.");

        if (GUILayout.Button("Add new Transform"))
        {
            wayPoints = (target as WayPointCurve).wayPoints;
            int numberOfWayPoints = wayPoints.Count;
            GameObject o = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            o.name = "Waypoint";
            DestroyImmediate(o.GetComponent<SphereCollider>());
            Object obj = null;
            if (numberOfWayPoints == 0)
                obj = Instantiate(o, (target as WayPointCurve).transform.position, new Quaternion());
            else
                obj = Instantiate(o, wayPoints[numberOfWayPoints - 1].transform.position, new Quaternion());
            //(obj as GameObject).transform.parent = curve.transform;
            wayPoints.Add((obj as GameObject).transform);
            DestroyImmediate(o);
        }
    }

    void ClearList()
    {
        wayPoints.RemoveAll(item => System.Object.ReferenceEquals(item, null) || item == null);
        foreach (Transform child in (target as BezierCurve).transform)
        {
            if (!wayPoints.Contains(child))
                DestroyImmediate(child.gameObject);
        }
    }

}
