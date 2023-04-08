using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGame : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool isDragging = false;

    public Rigidbody Rigidbody;
    public Vector3 Force;

    private void FixedUpdate()
    {
        Rigidbody.AddForce(Force, ForceMode.Force);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialPosition = Input.mousePosition;
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 currentPosition = Input.mousePosition;
            Vector3 difference = currentPosition - initialPosition;

            float speed = 0.001f;
            transform.position += new Vector3(0, 0, -difference.x * speed /2);
        }
    }
}
