//using UnityEngine;
//using UnityEditor;
//using System.Collections;

//[CustomEditor(typeof(Line), true)]
//public class LineEditor : CurveEditor
//{

//    Line line;
//    GameObject t0;
//    GameObject t1;

//    void OnEnable()
//    {
//        line = target as Line;
//        t0 = line.startingPoint;
//        t1 = line.endPoint;

//        t0 = EditorHelper.CreateSphereIfNull(t0, "Starting point", line.transform.position);
//        t1 = EditorHelper.CreateSphereIfNull(t1, "End point", line.transform.position);

//        line.startingPoint = t0;
//        line.endPoint = t1;

//        Debug.Log(t0);

//        t0.transform.parent = line.transform;
//        t1.transform.parent = line.transform;

//        t0.SetActive(true);
//        t1.SetActive(true);

//        base.DoOnEnable();
//    }

//    public override void OnInspectorGUI()
//    {
//        //if (GUILayout.Button("Update"))
//        //{
//        line.v0 = t0.transform.localPosition;
//        line.v1 = t1.transform.localPosition;
//        //}
//        base.OnInspectorGUI();
//    }

//    void OnDisable()
//    {
//        t0.SetActive(false);
//        t1.SetActive(false);
//    }

//    //void OnDestroy()
//    //{
//    //    Debug.Log("BOOM!");
//    //    DestroyImmediate(t1);
//    //    DestroyImmediate(t2);
//    //}

//}
