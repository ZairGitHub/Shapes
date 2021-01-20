﻿using UnityEngine;

public static class NullChecker
{
    public static Component TryGet<T>(Component component) where T : Component
    {
        return component == null ? new GameObject().AddComponent<T>() : component;
    }

    public static Component TryGet<T>(
        GameObject gameObject, Component component) where T : Component
    {
        if (gameObject == null)
        {
            return TryGet<T>(component);
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
