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

    public void ExitGame()
    {
        Application.Quit();
    }

    public void DificultySlider()
    {
        if(difficulty.value == 0)
        {
            GameManager.Instance.dificulty = 0;
        }

        if (difficulty.value == 1)
        {
            GameManager.Instance.dificulty = 1;
        }

        if (difficulty.value == 2)
        {
            GameManager.Instance.dificulty = 2;
        }
    }
}
