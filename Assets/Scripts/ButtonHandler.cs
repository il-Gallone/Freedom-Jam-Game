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
            case "Score Sky":
                SceneManager.LoadScene("Score Sky");
                break;
            case "Main Menu":
                SceneManager.LoadScene("Main Menu");
                break;
            case "Birdpedia":
                SceneManager.LoadScene("Birdpedia");
                break;
            case "Credits":
                SceneManager.LoadScene("Credits");
                break;
        }
    }


    public void Quit()
    {
        Application.Quit();
    }
}
