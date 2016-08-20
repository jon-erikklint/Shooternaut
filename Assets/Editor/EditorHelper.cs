using UnityEngine;
using System;
using System.Collections.Generic;

public static class EditorHelper {

    public static bool IsNullReference<T>(T element)
    {
        return System.Object.ReferenceEquals(element, null);
    }

    public static void RemoveNullReferences<T>(List<T> list)
    {
        list.RemoveAll(element => System.Object.ReferenceEquals(element, null) || element == null);
    }

    public static void RemoveNullReferences(List<Transform> list)
    {
        list.RemoveAll(element => System.Object.ReferenceEquals(element, null) || element == null || !element);
    }

    public static void RemoveNullReferences(List<MonoBehaviour> list)
    {
        list.RemoveAll(element => System.Object.ReferenceEquals(element, null) || element == null || !element);
    }

    public static void RemoveNullReferences(List<Curve> list)
    {
        list.RemoveAll(element => System.Object.ReferenceEquals(element, null) || element == null || !element);
    }

    public static GameObject CreateSphereIfNull(GameObject obj, string name, Vector3 pos)
    {
        if (IsNullReference(obj) || obj == null)
        {
            obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            obj.name = name;
            obj.transform.position = pos;
        }
        return obj;
    }

    public static GameObject CreateEmptyIfNull(GameObject obj, string name, Vector3 pos)
    {
        if (IsNullReference(obj) || obj == null)
        {
            obj = new GameObject(name);
            obj.transform.position = pos;
        }
        return obj;
    }

    public static void MakeEqualLength<S, T>(List<S> list1, List<T> list2, S element)
    {
        while (list1.Count > list2.Count)
            list1.RemoveAt(list2.Count);

        while (list1.Count < list2.Count)
            list1.Add(element);
    }

    static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
    {
        while (toCheck != null && toCheck != typeof(object))
        {
            var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
            if (generic == cur)
            {
                return true;
            }
            toCheck = toCheck.BaseType;
        }
        return false;
    }

}
