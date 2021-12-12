using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFollower : MonoBehaviour
{
    bool isPlayer = false;
    public PlayerFollower following;
    public float lastY = 0;
    public float speed;
    public Rigidbody2D rigid2D;
    float yCounter;
    public float rotationAngle = 15;
    bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            isPlayer = true;
        }
        DontDestroyOnLoad(gameObject);
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
            if (!isHit)
            {
                speed = following.speed;
                rigid2D.velocity = new Vector2(CameraMovement.moveSpeed, 0);
                float xDirection = 0;
                float yDirection = 0;
                if (following.transform.position.x - 2.6f > transform.position.x)
                {
                    xDirection = 1;
                }
                else if (following.transform.position.x - 2.4f < transform.position.x)
                {
                    xDirection = -1;
                }
                if (following.lastY - 0.1f > transform.position.y)
                {
                    yDirection = 1;
                    transform.eulerAngles = new Vector3(0, 0, rotationAngle);
                }
                else if (following.lastY + 0.1f < transform.position.y)
                {
                    yDirection = -1;
                    transform.eulerAngles = new Vector3(0, 0, -rotationAngle);
                }
                else
                {
                    transform.eulerAngles = Vector3.zero;
                }
                rigid2D.velocity += new Vector2(xDirection, yDirection) * speed;
            }
        }
        else
        {
            speed = gameObject.GetComponent<PlayerController>().speed;
            if(transform.position.x < CameraMovement.cameraX - gameObject.GetComponent<PlayerController>().screenWidth/2)
            {
                rigid2D.velocity += new Vector2(speed, 0);
            }
        }
    }

    public void BirdHit()
    {
        isHit = true;
        rigid2D.gravityScale = 2;
        rigid2D.angularVelocity = 90;
        Destroy(gameObject, 10);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "Score Sky")
        {
            if(isPlayer)
                ScoreBoard.birds = PlayerController.hp;
            Destroy(gameObject);
        }
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = new Vector3(-10, 0, 0);
        }
    }
}
