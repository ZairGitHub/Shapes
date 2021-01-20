using UnityEngine;

public class Movement
{
    public Vector3 Move(float horizontal, float vertical)
    {
        return new Vector3(horizontal, vertical, 0.0f);
    }
}