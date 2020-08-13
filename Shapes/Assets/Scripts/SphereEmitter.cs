using System.Collections;
using UnityEngine;

public class SphereEmitter : MonoBehaviour
{
    private GameObject sphere;
    
    private void Start()
    {
        sphere = GameObject.FindGameObjectWithTag("Sphere");
        StartCoroutine(EmitSpheres());
    }

    private IEnumerator EmitSpheres()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            Instantiate(sphere, Vector3.up, Quaternion.identity);
        }
    }
}
