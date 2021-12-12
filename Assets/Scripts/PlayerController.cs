using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigid2D;
    public GameObject cameraObject;
    public PlayerFollower lastFollower;
    public float screenHeight = 9;
    public float screenWidth = 16;
    public float speed = 3;
    public float rotationAngle = 15;

    public int hp;

    public int keyCount = 0;

    float invulnSecs = 0;
    float invulnFlash = 0;
    bool isFlash = false;
    

    private void Start()
    {
        hp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        rigid2D.velocity = new Vector2(CameraMovement.moveSpeed, 0);
        if (CameraMovement.cameraX <= CameraMovement.levelEndX)
        {
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
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
                if (hp > 0)
                {
                    lastFollower.BirdHit();
                    GameObject bird = lastFollower.gameObject;
                    lastFollower = lastFollower.following;

                    invulnSecs = 4;
                }
                else
                {
                    //TODO Death condition;
                }
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
                    PlayerFollower currentFollower = bird.GetComponent<PlayerFollower>();
                    currentFollower.following = lastFollower;
                    lastFollower = currentFollower;
                    hp++;
                }
            }
        }
    }
}
