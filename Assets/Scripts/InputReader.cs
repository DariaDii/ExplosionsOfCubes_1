using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private int _mouseButton = 0;

    public event Action LeftMouseCliked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButton))
        {
            LeftMouseCliked?.Invoke();
        }
    }
}