using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacleTopPrefab;
    public GameObject obstacleBotPrefab;
    public GameObject KeyPrefab;
    public GameObject CagePrefab;

    public GameObject cameraObject;
    float lastDistance;
    float nextDistance;
    public float minDistanceModifier;
    public float maxDistanceModifier;

    public float screenWidth = 16;
    public float screenHeight = 9;

    bool lastBonusKey = false;
    bool lastObstacleTop = true;

    int bonusCountdown = 3;
    // Start is called before the first frame update
    void Start()
    {
        lastDistance = screenWidth / 2;
        nextDistance = Random.Range(minDistanceModifier + CameraMovement.moveSpeed, maxDistanceModifier + CameraMovement.moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraObject.transform.position.x > lastDistance - screenWidth/2)
        {
            lastDistance += nextDistance;
            nextDistance = Random.Range(minDistanceModifier + CameraMovement.moveSpeed, maxDistanceModifier + CameraMovement.moveSpeed);
            if (lastObstacleTop)
            {
                lastObstacleTop = false;
                GameObject obstacle = Instantiate(obstacleBotPrefab, new Vector3(lastDistance, Random.Range(-6f, -3f), 0), Quaternion.identity);
                Destroy(obstacle, screenWidth / CameraMovement.moveSpeed + maxDistanceModifier + 4);
            }
            else if (!lastObstacleTop)
            {
                lastObstacleTop = true;
                GameObject obstacle = Instantiate(obstacleTopPrefab, new Vector3(lastDistance, Random.Range(3f, 6f), 0), Quaternion.identity);
                Destroy(obstacle, screenWidth / CameraMovement.moveSpeed + maxDistanceModifier + 4);
            }
        }
    }
}
