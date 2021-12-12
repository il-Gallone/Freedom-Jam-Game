using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageSpawn : MonoBehaviour
{
    public GameObject padlock;
    public List<GameObject> cagedBirds;
    public List<GameObject> birdFollowers;
    GameObject trappedBird;

    public bool isBirdFreed = false;

    int chosenBird;

    // Start is called before the first frame update
    void Start()
    {
        chosenBird = Random.Range(0, cagedBirds.Count);
        trappedBird = Instantiate(cagedBirds[chosenBird], transform.position + new Vector3(0, -0.2f), transform.rotation, gameObject.transform);
    }

    public GameObject FreeTheBird()
    {
        Destroy(padlock);
        Destroy(trappedBird);
        GameObject freedBird = Instantiate(birdFollowers[chosenBird], transform.position, Quaternion.identity);
        return freedBird;
    }
}
