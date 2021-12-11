using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMovementChecker : MonoBehaviour
{

    public GameObject cameraObject;
    public GameObject debugPrefab;

    float lastDistance = 0;
    public float debugDistance = 16;

    // Update is called once per frame
    void Update()
    {
        if(cameraObject.transform.position.x > lastDistance + debugDistance/2 - 2)
        {
            lastDistance += debugDistance;
            GameObject debugObject = Instantiate(debugPrefab, new Vector3(lastDistance, 0, 0), Quaternion.identity);
            Destroy(debugObject, (debugDistance + 4) / CameraMovement.moveSpeed);
        }
    }
}
