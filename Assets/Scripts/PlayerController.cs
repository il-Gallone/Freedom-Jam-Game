using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigid2D;
    public PlayerController following;
    public PlayerController followingMe;
    static public PlayerController lastFollower;
    public static float screenHeight;
    public static float screenWidth;
    public static float speed = 3;
    public float rotationAngle = 15;

    public static int hp = 1;

    public static int keyCount = 0;

    static float invulnSecs = 0;
    float invulnFlash = 0;
    bool isFlash = false;

    bool isPlayer = false;
    bool isHit = false;
    public float lastY = 0;
    float yCounter;


    private void Start()
    {
        screenWidth = 16;
        screenHeight = 9;
        if (gameObject.CompareTag("Player"))
        {
            isPlayer = true;
            lastFollower = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraMovement.cameraX <= CameraMovement.levelEndX && isPlayer)
        {
            rigid2D.velocity = new Vector2(CameraMovement.moveSpeed, 0);
            if (Input.GetAxis("Vertical") > 0 && transform.position.y <= screenHeight / 2 - 1)
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
            if (Input.GetAxis("Horizontal") < 0 && transform.position.x >= CameraMovement.cameraX - screenWidth / 2 + 1)
            {
                rigid2D.velocity -= new Vector2(speed, 0);
            }
            if (Input.GetAxis("Horizontal") > 0)
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
        yCounter += Time.deltaTime;
        if (yCounter >= 0.2f)
        {
            yCounter = 0;
            lastY = transform.position.y;
        }
        if (!isPlayer)
        {
            if (!isHit)
            {
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
            if (transform.position.x < CameraMovement.cameraX - PlayerController.screenWidth / 2)
            {
                rigid2D.velocity += new Vector2(speed, 0);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlayer)
        {
            AudioSource audioData = collision.gameObject.GetComponent<AudioSource>();
            if (CameraMovement.cameraX <= CameraMovement.levelEndX)
            {
                if (collision.CompareTag("Obstacle") && invulnSecs <= 0)
                {
                    if (audioData)
                    {
                        audioData.Play(0);
                    }
                    hp--;
                    BirdHit();
                }
                if (collision.CompareTag("Key"))
                {
                    if (audioData)
                    {
                        Debug.Log("collected key");
                        Debug.Log(audioData);
                        audioData.Play(0);
                    }
                    keyCount++;
                    collision.GetComponent<Renderer>().enabled = false;
                    Destroy(collision.gameObject, audioData.clip.length);
                }
                if (collision.CompareTag("Cage") && keyCount > 0)
                {
                    CageSpawn cage = collision.gameObject.GetComponent<CageSpawn>();
                    if (!cage.isBirdFreed)
                    {
                        keyCount--;
                        GameObject bird = cage.FreeTheBird();
                        PlayerController currentFollower = bird.GetComponent<PlayerController>();
                        currentFollower.following = lastFollower;
                        lastFollower.followingMe = currentFollower;
                        lastFollower = currentFollower;
                        hp++;
                    }
                }
            }
        }
    }
    public void BirdHit()
    {
        isPlayer = false;
        isHit = true;
        gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;
        if (hp > 0)
        {
            followingMe.BecomePlayer();
        }
        rigid2D.gravityScale = 2;
        rigid2D.angularVelocity = 135;
        Destroy(gameObject, 5);
    }

    public void BecomePlayer()
    {
        isPlayer = true;
        gameObject.tag = "Player";
        following = null;
        invulnSecs = 4;
        gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;
    }
    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "Score Sky")
        {
            if (isPlayer)
            {
                ScoreBoard.birds = hp;
                hp = 1;
                keyCount = 0;
            }
            Destroy(gameObject);
        }
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            hp = 1;
            keyCount = 0;
            Destroy(gameObject);
        }
        else
        {
            transform.position = new Vector3(-10, 0, 0);
        }
    }
}
