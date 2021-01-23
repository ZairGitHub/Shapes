using System;
using UnityEngine;

public static class NullChecker
{
    public static Component TryGet<T>(
        GameObject gameObject, Component component) where T : Component
    {
        if (gameObject == null)
        {
            return null;
        }
        return component == null ? gameObject.AddComponent<T>() : component;
    }

    public static Component TryGet<T>(GameObject gameObject) where T : Component
    {
        if (gameObject == null)
        {
            return null;
        }

        T component = gameObject.GetComponent<T>();
        if (component == null)
        {
            component = gameObject.AddComponent<T>();
        }
        return component;
    }

    public static Component TryFind<T>(string tag, GameObject gameObject) where T : Component
    {
        try
        {
            return GameObject.FindWithTag(tag).GetComponent<T>();
        }
        catch (NullReferenceException)
        {
            return gameObject.AddComponent<T>();
        }
    }

    public static GameObject TryGet(GameObject gameObject)
    {
        return gameObject == null ? new GameObject() : gameObject;
    }

    public static GameObject[] TryGet(GameObject[] gameObjects)
    {
        return gameObjects ?? new GameObject[0];
    }
}
