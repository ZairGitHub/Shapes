﻿using UnityEngine;

public static class NullChecker
{
    public static Component TryGet<T>(T component) where T : Component
    {
        return component ?? new GameObject().AddComponent<T>();
    }

    public static Component TryGet<T>(
        GameObject gameObject, Component component) where T : Component
    {
        if (gameObject == null)
        {
            return TryGet(component);
        }
        return component == null ? gameObject.AddComponent<T>() : component;
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
