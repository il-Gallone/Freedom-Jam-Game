using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{

    public Text text;
    public string id;
    public PlayerController player;

    // Update is called once per frame
    void Update()
    {
        if (id == "HP")
            text.text = "HP: " + player.hp.ToString();
        if (id == "keys")
            text.text = "Keys: " + player.keyCount.ToString();
    }
}
