using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGame : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Transform playerTransform;
    private bool isMouseButtonDown = false;
    private float mouseDownX;

    public Rigidbody Rigidbody;
    public Vector3 Force;

    private void FixedUpdate()
    {
        Rigidbody.AddForce(Force, ForceMode.Force);
    }

    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 currentPosition = playerTransform.position;

        if (Input.GetMouseButtonDown(0))
        {
            isMouseButtonDown = true;
            mouseDownX = Input.mousePosition.z;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMouseButtonDown = false;
        }

        if (isMouseButtonDown)
        {
            float mouseDeltaX = Input.mousePosition.z - mouseDownX;
            currentPosition.z += mouseDeltaX * moveSpeed * Time.deltaTime;
        }

        playerTransform.position = currentPosition;
    }
}
