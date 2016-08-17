using UnityEngine;
using System.Collections.Generic;

public static class ListExtension<T> {

    public static void AddElement(List<T> list, T element)
    {
        list.Add(element);
    }

    public static void Clean(List<T> list)
    {
        list.RemoveAll(null);
    }

}
