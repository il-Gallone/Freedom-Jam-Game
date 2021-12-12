using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressSlider : MonoBehaviour
{

    public Slider slider;
    public GameObject victoryScreen;

    // Update is called once per frame
    void Update()
    {
        slider.value = CameraMovement.cameraX;
        if(slider.value >= slider.maxValue)
        {
            victoryScreen.SetActive(true);
        }
    }
}
