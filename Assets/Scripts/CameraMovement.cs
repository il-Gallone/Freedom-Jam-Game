using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float startSpeed = 1;
    public static float cameraX = 0;
    public float levelEndChanger;
    public static float levelEndX;
    public static float moveSpeed = 1;
    public float accelRate = 0.05f;
    public Rigidbody2D rigid2D;

    // Update is called once per frame
    private void Start()
    {
        levelEndX = levelEndChanger;
        moveSpeed = startSpeed;
    }

    void Update()
    {
        if (cameraX <= levelEndX && PlayerController.hp > 0)
        {
            cameraX = transform.position.x;
            moveSpeed += accelRate * Time.deltaTime;
            rigid2D.velocity = new Vector2(moveSpeed, 0);
            if (GameObject.FindGameObjectWithTag("Player").transform.position.x > transform.position.x + PlayerController.screenWidth / 4)
            {
                moveSpeed += accelRate * PlayerController.speed / moveSpeed * Time.deltaTime;
                rigid2D.velocity += new Vector2(PlayerController.speed, 0);
            }
        }
        else
        {
            rigid2D.velocity = Vector2.zero;
        }
    }
}
