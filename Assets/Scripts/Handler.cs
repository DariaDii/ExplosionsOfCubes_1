using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosioner _explosioner;

    [SerializeField] private int _minSpawnAmount = 2;
    [SerializeField] private int _maxSpawnAmount = 6;

    private int _splitChanceMin = 1;
    private int _splitChanceMax = 100;

    private void OnEnable()
    {
        _raycaster.CubeHit += OnCubeHit;
    }

    private void OnDisable()
    {
        _raycaster.CubeHit += OnCubeHit;
    }

    private void OnCubeHit(Cube cubeHit)
    {
        List<Cube> newCubes = new List<Cube>();

        if (CanSplit(cubeHit.SplitChance))
        {
            newCubes = _spawner.SpawnCubes(NumberOfNewCubes(),cubeHit,_colorChanger);
        }
        else
        {
            newCubes = null;
        }

        _explosioner.Explode(newCubes, cubeHit);
    }

    private bool CanSplit(float splitChance)
    {
        return Random.Range(_splitChanceMin,_splitChanceMax+1)<=splitChance;
    }

    private int NumberOfNewCubes()
    {
        return Random.Range(_minSpawnAmount, _maxSpawnAmount + 1);
    }
}