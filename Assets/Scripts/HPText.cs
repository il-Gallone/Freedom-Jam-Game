using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{

    public Text text;
    public PlayerController player;

    // Update is called once per frame
    void Update()
    {
        text.text = "HP: " + player.hp.ToString();
    }
}
