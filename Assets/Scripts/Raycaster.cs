using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputReader _inputReader;

    public event Action<Cube> CubeHit;

    private void OnEnable()
    {
        _inputReader.LeftMouseCliked += OnMouseClicked;
    }

    private void OnDisable()
    {
        _inputReader.LeftMouseCliked -= OnMouseClicked;
    }

    private void OnMouseClicked()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.TryGetComponent(out Cube cube))
            {
                CubeHit?.Invoke(cube);
            }
        }
    }
}