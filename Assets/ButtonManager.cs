using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [Header("Refrenses")]
    public GameObject settingsScreen;
    public GameObject menuScreen;
    public Slider difficulty;
    GameManager settings;

    private void Start()
    {
        settings = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


    public void Settings()
    {
        menuScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void CloseSettings()
    {
        menuScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }

    public void DificultySlider()
    {
        if(difficulty.value == 0)
        {
            settings.dificulty = 0;
        }

        if (difficulty.value == 1)
        {
            settings.dificulty = 1;
        }

        if (difficulty.value == 2)
        {
            settings.dificulty = 2;
        }
    }
}
