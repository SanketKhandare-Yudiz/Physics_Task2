using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Rigidbody2D player;
    private float moveSpeed = 2f;

    void Update()
    {
        if (player.velocity == Vector2.zero)
        {
            cameraMovment();
        }

    }
    public void cameraMovment()
    {
        Vector3 newPos = new Vector3(player.position.x + 4f, transform.position.y, transform.position.z);
        //Vector3 newPos = Vector3.Lerp(transform.position.x,Vector3.right,0);
        transform.position = Vector3.Lerp(transform.position, newPos, moveSpeed * Time.deltaTime);
    }


}

