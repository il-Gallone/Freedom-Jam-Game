using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{

    public Text text;
    public string id;

    // Update is called once per frame
    void Update()
    {
        if (id == "HP")
            text.text = "HP: " + PlayerController.hp.ToString();
        if (id == "keys")
            text.text = "Keys: " + PlayerController.keyCount.ToString();
    }
}
