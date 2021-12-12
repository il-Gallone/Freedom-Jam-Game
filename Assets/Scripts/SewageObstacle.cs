using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewageObstacle : MonoBehaviour
{
    bool movingUp = false;
    public float moveSpeed = 1;

    public Rigidbody2D rigid2D;


    // Update is called once per frame
    void Update()
    {
        if (movingUp)
        {
            rigid2D.velocity = new Vector2(0, moveSpeed);
            if (transform.position.y > -2.9f)
            {
                movingUp = false;
            }
        }
        else
        {
            rigid2D.velocity = new Vector2(0, -moveSpeed);
            if (transform.position.y < -5.9f)
            {
                movingUp = true;
            }
        }
    }
}
