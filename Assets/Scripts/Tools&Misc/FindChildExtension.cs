using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FindChildExtension
{
    public static Transform FindComponentInChildWithTag<T>(this GameObject parent, string tag) where T : Component
    {
        Transform t = parent.transform;
        foreach (Transform tr in t)
        {
            if (tr.tag == tag)
            {
                return tr.GetComponent<Transform>();
            }
        }
        return null;
    }
}
