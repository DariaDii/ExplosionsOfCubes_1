using System.Collections.Generic;
using UnityEngine;

public class Explosioner : MonoBehaviour
{
    [SerializeField] private float _pushForce = 10f;
    [SerializeField] private float _spinForce = 750f;

    private ForceMode _forceMode = ForceMode.Impulse;

    public void Explode(List<Cube> cubes, Cube originCube)
    {
        if (cubes != null)
        {
            ScatterSpawnedCubes(cubes, originCube);
        }

        DestroyCube(originCube);
    }

    private void ScatterSpawnedCubes(List<Cube> cubes,Cube originCube)
    {
        foreach (Cube cube in cubes)
        {
            Push(cube, originCube.transform.position);
            Spin(cube);
        }
    }    

    private void Push(Cube cube, Vector3 originPoint)
    {
        Vector3 direction = cube.transform.position - originPoint;
        direction.Normalize();
        cube.Rigidbody.AddForce(direction*_pushForce,_forceMode);
    }

    private void Spin(Cube cube)
    {
        Vector3 randomTorque = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        cube.Rigidbody.AddTorque(randomTorque*_spinForce);
    }

    private void DestroyCube(Cube cube)
    {
        cube.gameObject.SetActive(false);
        Destroy(cube.gameObject);
    }
}