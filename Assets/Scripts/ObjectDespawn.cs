using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDespawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < CameraMovement.cameraX - 30)
        {
            Destroy(gameObject);
        }
    }
}
