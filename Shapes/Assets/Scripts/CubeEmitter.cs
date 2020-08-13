using System.Collections;
using UnityEngine;

public class CubeEmitter : MonoBehaviour
{
    private GameObject cube;

    private void Start()
    {
        cube = GameObject.FindGameObjectWithTag("Cube");
        StartCoroutine(EmitCubes());
    }

    private IEnumerator EmitCubes()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);           
            CubeHandler cubeObject = Instantiate(cube, transform.position + Vector3.up, Quaternion.identity).GetComponent<CubeHandler>();
            cubeObject.SetDirection(1, -1);
        }
    }
}
