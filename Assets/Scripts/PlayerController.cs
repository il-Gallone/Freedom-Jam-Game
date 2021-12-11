using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigid2D;
    public GameObject cameraObject;
    public float screenHeight = 9;
    public float screenWidth = 16;
    public float speed = 3;
    public float rotationAngle = 15;

    // Update is called once per frame
    void Update()
    {
        float cameraX = cameraObject.transform.position.x;
        rigid2D.velocity = new Vector2(CameraMovement.moveSpeed, 0);
        if(Input.GetAxis("Vertical") > 0 && transform.position.y <=  screenHeight/2 - 1)
        {
            rigid2D.velocity += new Vector2(0, speed);
            transform.eulerAngles = new Vector3(0, 0, rotationAngle);
        }
        else if (Input.GetAxis("Vertical") < 0 && transform.position.y >= -screenHeight / 2 + 1)
        {
            rigid2D.velocity -= new Vector2(0, speed);
            transform.eulerAngles = new Vector3(0, 0, -rotationAngle);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
        if (Input.GetAxis("Horizontal") < 0 && transform.position.x >= cameraX - screenWidth/2 + 1)
        {
            rigid2D.velocity -= new Vector2(speed, 0);
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            rigid2D.velocity += new Vector2(speed, 0);
        }
    }
}
