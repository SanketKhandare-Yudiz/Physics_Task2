using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class LineRenderer_Script : MonoBehaviour
{
    public Transform midCube;
    public Transform player;
    [SerializeField] private DistanceJoint2D joint;
    [SerializeField] private LineRenderer line;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Rigidbody2D rb;
    private float speed = 3f;
    public Ui_Manager uiManager;

    private void Awake()
    {
        Application.targetFrameRate = 120;
    }
    void Start()
    {
        joint.connectedBody = null;
        line.enabled = false;
    }


    private void FixedUpdate()
    {
        Vector2 Bound = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 temp = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, transform.position.x, Bound.x), Mathf.Clamp(transform.position.y, transform.position.y, Bound.y), 0);
    }
    private void Update()
    {
        DrawLine();
        InputManager();
    }

     void InputManager()
    {
        if (uiManager.startButtonPressed == true)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                joint.connectedAnchor -= new Vector2(0, 0.1f);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                joint.connectedAnchor += new Vector2(0, 0.1f);
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                //   player.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, player.transform.position.y) * speed;
                player.GetComponent<Rigidbody2D>().velocity =  Vector2.right * speed;
            }
            if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //player.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, player.transform.position.y) * speed;
                player.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                joint.connectedBody = null;
                line.enabled = false;
            }

            if((Input.GetMouseButtonDown(0)))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, layerMask);

                if (joint.connectedBody == null && hit.collider != null)
                {
                    joint = hit.collider.gameObject.GetComponent<DistanceJoint2D>();
                    joint.connectedBody = rb;
                    line.enabled = true;
                }  
            }
        }
     }
    void DrawLine()
    {  if (joint.connectedBody != null)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, joint.transform.position);
        }
    }    
}
