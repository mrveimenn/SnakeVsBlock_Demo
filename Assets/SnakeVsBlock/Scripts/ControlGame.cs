using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGame : MonoBehaviour
{
    private Vector3 previousMousePosition;

    public Rigidbody player;
    public float speed;
    public float sense;

    private void FixedUpdate()
    {
        Moving(player);

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - previousMousePosition;
            player.velocity = new Vector3(speed, 0.0f, -delta.x * sense);
        }

        previousMousePosition = Input.mousePosition;
    }

    public void Moving(Rigidbody rb)
    {
        rb.velocity = Vector3.right * speed;
    }
}
