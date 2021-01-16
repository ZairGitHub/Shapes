using UnityEngine;

public static class NullComponentChecker
{
    public static Component TryGet<T>(
        GameObject gameObject, Component component) where T : Component
    {
        return component == null ? gameObject.AddComponent<T>() : component;
    }
}
