using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float startSpeed = 1;
    public static float cameraX = 0;
    public static float moveSpeed = 1;
    public float accelRate = 0.05f;
    public Rigidbody2D rigid2D;
    public PlayerController player;

    // Update is called once per frame
    private void Start()
    {
        moveSpeed = startSpeed;
    }

    void Update()
    {
        cameraX = transform.position.x;
        moveSpeed += accelRate*Time.deltaTime;
        rigid2D.velocity = new Vector2(moveSpeed, 0);
        if(player.transform.position.x > transform.position.x + player.screenWidth/4)
        {
            moveSpeed += accelRate *player.speed/moveSpeed * Time.deltaTime;
            rigid2D.velocity += new Vector2(player.speed, 0);
        }
    }
}
