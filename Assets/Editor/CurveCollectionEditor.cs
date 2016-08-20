using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(CurveCollection), true)]
public class CurveCollectionEditor : CurveEditor {

    CurveCollection curveCollection;
    List<Curve> curves;

    void OnEnable()
    {
        curveCollection = target as CurveCollection;
        curves = curveCollection.curves;
        base.DoOnEnable();
    }

    public override void OnInspectorGUI()
    {
        if(curves != null)
        {
            EditorHelper.RemoveNullReferences(curves);
        }
        base.OnInspectorGUI();
    }

    public void OnSceneGUI()
    {
        Event e = Event.current; if ((e.type == EventType.MouseDown) && e.button == 0)
        {
            Debug.Log("moi");
            /* Do stuff
               * * * *
             * */
            e.Use();  //Eat the event so it doesn't propagate through the editor.
        }
    }

}
