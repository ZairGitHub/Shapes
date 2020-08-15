using System.Collections;
using System.Linq;
using UnityEngine;

public class CubeEmitter : MonoBehaviour
{
    private GameObject cube;
    private GameObject[] cubeEmitters;

    private EmitterDirection emitterDirection;

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
            int RNG = Random.Range(0, cubeEmitters.Length);
            cubeEmitters[RNG].GetComponent<Renderer>().material.color = Color.blue;
            emitterDirection = cubeEmitters[RNG].GetComponent<EmitterDirection>();

            yield return new WaitForSeconds(1);

            CubeHandler cubeObject = Instantiate(cube, cubeEmitters[RNG].transform.position + Vector3.up, Quaternion.identity).GetComponent<CubeHandler>();
            cubeObject.SetDirection(emitterDirection.GetXDirection(), emitterDirection.GetZDirection());

            cubeEmitters[RNG].GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
