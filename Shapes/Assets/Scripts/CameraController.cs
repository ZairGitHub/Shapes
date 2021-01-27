using UnityEngine;

public class CameraController : MonoBehaviour
{
    private readonly Vector3 _offset = new Vector3(0.0f, 0.0f, -10.0f);
    
    private void Awake() => SetPosition(_offset);

    public void RunTestingConstructor(Vector3 offset) => SetPosition(offset);
    
    private void SetPosition(Vector3 offset) => transform.position = offset;
}
