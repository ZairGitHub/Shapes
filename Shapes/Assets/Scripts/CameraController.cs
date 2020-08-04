using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;
    
    private void Start()
    {
        offset = new Vector3(0, 20, 0);
        transform.rotation = Quaternion.Euler(90, 0, 0);
        transform.position = offset;
    }
}
