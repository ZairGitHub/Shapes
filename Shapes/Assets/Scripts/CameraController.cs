using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 _offset;
    
    private void Start()
    {
        _offset = new Vector3(0.0f, 0.0f, -10.0f);
        transform.position = _offset;
    }
}
