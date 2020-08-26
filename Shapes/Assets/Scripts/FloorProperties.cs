using UnityEngine;

public class FloorProperties : MonoBehaviour
{
    private Quaternion rotation;

    private void Awake()
    {
        rotation = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
        transform.rotation = rotation;

        GetComponent<Renderer>().material.color = Color.black;
    }
}
