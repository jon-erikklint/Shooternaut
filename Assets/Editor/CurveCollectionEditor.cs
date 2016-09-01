//using UnityEngine;
//using UnityEditor;
//using System.Collections.Generic;

//[CustomEditor(typeof(CurveCollection), true)]
//public class CurveCollectionEditor : CurveEditor {

//    CurveCollection curveCollection;
//    List<Curve> curves;

//    protected override void DoOnEnable()
//    {
//        curveCollection = target as CurveCollection;
//        curves = curveCollection.curves;
//        base.DoOnEnable();
//    }

//    public override void OnInspectorGUI()
//    {
//        if(curves != null)
//        {
//            EditorHelper.RemoveNullReferences(curves);
//        }
//        base.OnInspectorGUI();
//    }

//}
