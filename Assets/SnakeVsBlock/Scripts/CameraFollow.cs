using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Player Player;
    void LateUpdate()
    {
        if (Player != null)
            transform.position = new Vector3(Player.transform.position.x - 6f, 15f, 0);
    }
}