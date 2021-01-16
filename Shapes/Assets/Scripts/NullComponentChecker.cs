using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class NullComponentChecker
{
    public static Component TryGet<T>(GameObject gameObject, Component c) where T : Component
    {
        if (c == null)
        {
            return gameObject.AddComponent<T>();
        }
        return c;
    }

}
