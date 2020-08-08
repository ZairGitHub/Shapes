using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;
    
    private void Start()
    {
        offset = new Vector3(0.0f, 20.0f, 0.0f);
        transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);

        transform.position = offset;
    }
}
