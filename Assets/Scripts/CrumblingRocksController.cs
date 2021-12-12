using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblingRocksController : MonoBehaviour
{

    public GameObject rockPrefab;
    float timeAlive = 0;
    bool rockSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(CameraMovement.cameraX + CameraMovement.moveSpeed * Random.Range(5f, 6.5f), 4f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        if(timeAlive >= 5 && !rockSpawned)
        {
            rockSpawned = true;
            Debug.Log("Rock Spawned");
            Instantiate(rockPrefab, transform.position, Quaternion.identity);
        }
        if(timeAlive >= 6)
        {
            Destroy(gameObject);
        }
    }
}
