using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

   public List<Cube> SpawnCubes(int amount, Cube cube,ColorChanger newColor)
    {
        Vector3 newCubeScale = cube.transform.localScale / 2;
        float newSplitChance = cube.SplitChance / 2;

        List<Cube> newCubes = new List<Cube>();

        for (int i = 0; i < amount; i++)
        {
            Cube newCube = Instantiate(_cubePrefab);

            newCube.Initialize(newSplitChance);
            SetTransformValues(cube, newCube, newCubeScale);
            newColor.ChangeToRandomColor(newCube.Renderer);            
            newCubes.Add(newCube);
        }

        return newCubes;
    }

    private void SetTransformValues(Cube originCube, Cube newCube, Vector3 scale)
    {
        Vector3 randomDirection = Random.insideUnitCircle;
        Vector3 spawnOffset = randomDirection * scale.x;
        Vector3 spawnPosition = originCube.transform.position + spawnOffset;

        newCube.transform.position = spawnPosition;
        newCube.transform.localScale = scale;
    }
}