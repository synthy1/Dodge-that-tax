using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose_Win_Buttons : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Retrylmao()
    {
        SceneManager.LoadScene(1);
    }
    public void GoBackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
