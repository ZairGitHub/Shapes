using UnityEngine;

/*
 * Created to prevent code reuse of null component checks
 * but ended up being more convoluted and harder to read.
 * 
 * This class may be later deleted in the future.
 */
public static class NullComponentChecker
{
    public static Component TryGet<T>(
        GameObject gameObject, Component component) where T : Component
    {
        return component == null ? gameObject.AddComponent<T>() : component;
    }
}
