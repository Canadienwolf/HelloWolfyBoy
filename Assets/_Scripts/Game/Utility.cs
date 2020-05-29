using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public static class Utility
{
//    /// <summary>
//    /// Returns a dynamic list of child objects.
//    /// If the object has no children, returns null.
//    /// </summary>
//    /// <param name="parent"></param>
//    /// <returns></returns>
    public static List<GameObject> GetChildrenInList(this GameObject parent)
    {
        List<GameObject> list = new List<GameObject>();

        if (parent.transform.childCount == 0) return null;

        for (int i = 0; i < parent.transform.childCount; i++)
        {
            list.Add(parent.transform.GetChild(i).gameObject);
        }

        return list;
    }

    public static List<T> GetChildrenInList<T>(this GameObject parent)
    {
        List<T> list = new List<T>();

        if (parent.transform.childCount == 0) return null;

        for (int i = 0; i < parent.transform.childCount; i++)
        {
            list.Add(parent.transform.GetChild(i).GetComponent<T>());
        }

        return list;
    }

    public static List<T> Collect<T>(this IEnumerable enumerable)
    {
        var list = new List<T>();
        foreach (T item in enumerable) list.Add(item);
        return list;
    }

    public static T[] Shuffle<T>(this T[] array)
    {
        int n = array.Length;

        for (int i = 0; i < n; i++)
        {
            int r = i + Random.Range(0, n - i);
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }

        return array;
    }

    public static List<T> Shuffle<T>(this List<T> list)
    {
        int n = list.Count;

        for (int i = 0; i < n; i++)
        {
            int r = i + Random.Range(0, n - i);
            T t = list[r];
            list[r] = list[i];
            list[i] = t;
        }

        return list;
    }

    public static T RandomElement<T>(this T[] array)
    {
        if (array.Length == 1)
            return array[0];
        else if (array.Length == 0)
            throw new Exception("Array is empty!");
        return array[Random.Range(0, array.Length)];
    }

    public static T RandomElement<T>(this List<T> list)
    {
        if (list.Count == 1)
            return list[0];
        else if (list.Count == 0)
            throw new Exception("List is empty!");
        return list[Random.Range(0, list.Count)];
    }

    public static void ForEach<T>(this IEnumerable<T> objects, Action<T> action)
    {
        objects.ToList().ForEach(action);
    }
}