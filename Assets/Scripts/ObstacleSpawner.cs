using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacleTopPrefab;
    public GameObject obstacleBotPrefab;
    public GameObject obstacleExtPrefab;
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
    public int bonusDistance = 5;
    int extraCountdown = 0;
    public int extraDistance = -1;
    // Start is called before the first frame update
    void Start()
    {
        lastDistance = screenWidth / 2;
        nextDistance = Random.Range(minDistanceModifier + CameraMovement.moveSpeed, maxDistanceModifier + CameraMovement.moveSpeed);
        if (extraDistance == -1)
        {
            extraCountdown = -1;
        }
        else
        {
            extraCountdown = extraDistance + Random.Range(-2, +3);
        }
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
                Instantiate(obstacleBotPrefab, new Vector3(lastDistance, Random.Range(-6f, -3f), 0), Quaternion.identity);
            }
            else
            {
                lastObstacleTop = true;
                Instantiate(obstacleTopPrefab, new Vector3(lastDistance, Random.Range(3f, 6f), 0), Quaternion.identity);
            }
            bonusCountdown--;
            if(extraCountdown != -1)
            {
                extraCountdown--;
            }
        }
        if(bonusCountdown == 0)
        {
            bonusCountdown = bonusDistance + Random.Range(-1, 2);
            Vector3 spawnPositon;
            if (lastObstacleTop)
            {
                spawnPositon = new Vector3(lastDistance + nextDistance / 2, Random.Range(-3f, -1f), 0);
            }
            else
            {
                spawnPositon = new Vector3(lastDistance + nextDistance / 2, Random.Range(1f, 3f), 0);
            }
            if(lastBonusKey)
            {
                lastBonusKey = false;
                Instantiate(CagePrefab, spawnPositon, Quaternion.identity);
            }
            else
            {
                lastBonusKey = true;
                Instantiate(KeyPrefab, spawnPositon, Quaternion.identity);
            }
        }
        if(extraCountdown == 0)
        {
            extraCountdown = extraDistance + Random.Range(-2, +3);
            Instantiate(obstacleExtPrefab);
        }
    }
}
