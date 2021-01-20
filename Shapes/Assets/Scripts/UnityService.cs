using UnityEngine;

public class UnityService : IUnityService
{
    public float GetAxis(string axis)
    {
        return Input.GetAxis(axis);
    }
}
