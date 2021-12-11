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

    public int hp;
    public int birds = 1;
    public int hpModifier;

    float invulnSecs = 0;
    float invulnFlash = 0;
    bool isFlash = false;

    private void Start()
    {
        hp = birds * hpModifier;
    }

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
        if (invulnSecs > 0)
        {
            invulnSecs -= Time.deltaTime;
            invulnFlash += Time.deltaTime;
            if (invulnFlash >= 0.3f)
            {
                if (isFlash)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f);
                    isFlash = false;
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0.8f, 0.8f, 0.8f);
                    isFlash = true;
                }
            }
            if (invulnSecs <= 0)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") && invulnSecs <= 0)
        {
            hp--;
            invulnSecs = 4;
            //TODO Death condition;
        }
    }
}
