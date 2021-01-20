using UnityEngine;

public class UnityService : IUnityService
{
    public float GetAxisRaw(string axis)
    {
        return Input.GetAxisRaw(axis);
    }
}
