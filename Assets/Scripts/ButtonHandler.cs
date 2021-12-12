using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();

        button.onClick.AddListener(HandleClick);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void HandleClick()
    {
        Debug.Log("button clicked");
        switch(button.name)
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
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Debug.Log("I quit!");
        Application.Quit();
    }
}
