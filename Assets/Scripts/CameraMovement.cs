using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float startSpeed = 1;
    public static float moveSpeed = 1;
    public float accelRate = 0.05f;
    public Rigidbody2D rigid2D;
    public PlayerController player;

    // Update is called once per frame
    void Update()
    {
        moveSpeed = startSpeed + transform.position.x * accelRate;
        rigid2D.velocity = new Vector2(moveSpeed, 0);
        if(player.transform.position.x > transform.position.x + player.screenWidth/4)
        {
            rigid2D.velocity += new Vector2(player.speed, 0);
        }
    }
}
