using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    bool isPlayer = false;
    public PlayerFollower following;
    public float lastY = 0;
    public float speed;
    public Rigidbody2D rigid2D;
    float yCounter;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        yCounter += Time.deltaTime;
        if(yCounter >= 0.2f)
        {
            yCounter = 0;
            lastY = transform.position.y;
        }
        if (!isPlayer)
        {
            speed = following.speed;
            rigid2D.velocity = new Vector2(CameraMovement.moveSpeed, 0);
            float xDirection = 0;
            float yDirection = 0;
            if (following.transform.position.x - 2.6f > transform.position.x)
            {
                xDirection = 1;
            }
            else if(following.transform.position.x - 2.4f < transform.position.x)
            {
                xDirection = -1;
            }
            if (following.lastY -0.1f > transform.position.y)
            {
                yDirection = 1;
            }
            else if (following.lastY +0.1f < transform.position.y)
            {
                yDirection = -1;
            }
            rigid2D.velocity += new Vector2(xDirection, yDirection) * speed;
        }
        else
        {
            speed = gameObject.GetComponent<PlayerController>().speed;
        }
    }
}
