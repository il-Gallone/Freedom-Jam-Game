using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecartSpeed : MonoBehaviour
{
    float speed = 20;
    public Rigidbody2D rigid2D;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(CameraMovement.cameraX + CameraMovement.moveSpeed * Random.Range(5f, 6.5f), -2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        speed += Time.deltaTime * 0.5f;
        rigid2D.velocity = new Vector2(-speed + CameraMovement.moveSpeed, 0);
    }
}
