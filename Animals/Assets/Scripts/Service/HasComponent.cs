using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HasComponent
{
    public static bool Check<T>(this GameObject obj)
    {
        return (obj.GetComponent<T>() as Component) != null;
    }
}
