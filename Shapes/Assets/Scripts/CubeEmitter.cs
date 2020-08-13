using System.Collections;
using System.Linq;
using UnityEngine;

public class CubeEmitter : MonoBehaviour
{
    private GameObject cube;
    private GameObject[] cubeEmitters;

    private void Start()
    {
        cube = GameObject.FindGameObjectWithTag("Cube");
        cubeEmitters = GameObject.FindGameObjectsWithTag("CubeEmitter").OrderBy(gameObject => gameObject.name).ToArray();
        StartCoroutine(EmitCubes());
    }

    private IEnumerator EmitCubes()
    {
        while (true)
        {
            int RNG = Random.Range(1, 101);
            yield return new WaitForSeconds(1);

            if (RNG < 25)
            {
                CubeHandler cubeObject = Instantiate(cube, cubeEmitters[0].transform.position + Vector3.up, Quaternion.identity).GetComponent<CubeHandler>();
                cubeObject.SetDirection(1, -1);
            }
            else if (RNG < 50)
            {
                CubeHandler cubeObject = Instantiate(cube, cubeEmitters[1].transform.position + Vector3.up, Quaternion.identity).GetComponent<CubeHandler>();
                cubeObject.SetDirection(-1, -1);
            }
            else if (RNG < 75)
            {
                CubeHandler cubeObject = Instantiate(cube, cubeEmitters[2].transform.position + Vector3.up, Quaternion.identity).GetComponent<CubeHandler>();
                cubeObject.SetDirection(1, 1);
            }
            else
            {
                CubeHandler cubeObject = Instantiate(cube, cubeEmitters[3].transform.position + Vector3.up, Quaternion.identity).GetComponent<CubeHandler>();
                cubeObject.SetDirection(-1, 1);
            }
        }
    }
}
