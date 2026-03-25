using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private int _leftMouseButton = 0;

    public event Action LeftMouseCliked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
            LeftMouseCliked?.Invoke();
        }
    }
}