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
                StartGame();
                break;
            case "Quit":
                Quit();
                break;
        }
    }

    public void StartGame()
    {
        Debug.Log("test successful");
        SceneManager.LoadScene("SewerScene");
    }

    public void Quit()
    {
        Debug.Log("I quit!");
        Application.Quit();
    }
}
