using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public static int birds = 0;
    public GameObject bird1;
    public GameObject bird2;
    public GameObject bird3;
    public Text text;
    private void Start()
    {
        if(birds < 4)
        {
            bird3.SetActive(false);
            text.text = "You escaped with 2 friends. Flying High!";
        }
        if (birds < 3)
        {
            bird2.SetActive(false);
            text.text = "You escaped with 1 friend. BFFs!";
        }
        if (birds < 2)
        {
            bird1.SetActive(false);
            text.text = "You escaped but all on your own. Try and rescue some more friends.";
        }
        if(birds >= 4)
        {
            text.text = "You escaped with " + birds.ToString() + " friends! Fly Free!";
        }
    }

}
