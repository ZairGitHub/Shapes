using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    private Quaternion rotation;

    private void Start()
    {
        rotation = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
        transform.rotation = rotation;
    }
}
