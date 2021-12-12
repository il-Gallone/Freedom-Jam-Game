using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{  


    public void HandleClick(string id)
    {
        Debug.Log("button clicked");
        switch(id)
        {
            case "Story Mode":
                SceneManager.LoadScene("SewerScene");
                break;
            case "Quit":
                Quit();
                break;
            case "Enter Caves":
                SceneManager.LoadScene("CaveScene");
                break;
            case "Enter Mines":
                SceneManager.LoadScene("MineScene");
                break;
        }
    }


    public void Quit()
    {
        Application.Quit();
    }
}
