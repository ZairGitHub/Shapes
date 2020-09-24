using System.Collections;
using System.Linq;
using UnityEngine;

public class CubeEmitter : MonoBehaviour
{
    private GameObject _cube;
    private GameObject[] _cubeEmitters;
    private GameController _gameController;
    private EmitterProperties _emitterProperties;

    private void Start()
    {
        _cube = GameObject.FindGameObjectWithTag("Cube");
        _cubeEmitters = GameObject.FindGameObjectsWithTag("CubeEmitter").OrderBy(gameObject => gameObject.name).ToArray();
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        foreach (GameObject cubeEmitter in _cubeEmitters)
        {
            cubeEmitter.transform.position = cubeEmitter.GetComponent<EmitterProperties>().SetAndGetPosition();
        }

        StartCoroutine(EmitCubes());
    }

    private IEnumerator EmitCubes()
    {
        while (_gameController.IsRunning)
        {
            int RNG = Random.Range(0, _cubeEmitters.Length);
            _cubeEmitters[RNG].GetComponent<Renderer>().material.color = Color.blue;
            _emitterProperties = _cubeEmitters[RNG].GetComponent<EmitterProperties>();

            yield return new WaitForSeconds(1);

            if (_gameController.IsRunning)
            {
                CubeHandler cubeObject = Instantiate(_cube, _cubeEmitters[RNG].transform.position, Quaternion.identity).GetComponent<CubeHandler>();
                cubeObject.SetDirection(_emitterProperties.SetAndGetXDirection(), _emitterProperties.SetAndGetYDirection());

                _cubeEmitters[RNG].GetComponent<Renderer>().material.color = Color.yellow;
            }
        }
    }
}
