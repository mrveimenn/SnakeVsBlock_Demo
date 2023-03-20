using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGame : MonoBehaviour
{
    public float Sense;
    public Transform Player;
    private Vector3 _previousMousePosition;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            Player.Rotate(-delta.y * Sense, 0, 0);
        }
        _previousMousePosition = Input.mousePosition;
    }
}
