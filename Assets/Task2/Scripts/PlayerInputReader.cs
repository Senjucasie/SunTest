using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputReader : MonoBehaviour
{
    public event Action<Vector3> MouseButtonPressed;
    public event Action MouseButtonUp;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            MouseButtonPressed?.Invoke(Input.mousePosition);
        }    
        if(Input.GetMouseButtonUp(0))
        {
            MouseButtonUp?.Invoke();
        }

    }
}
