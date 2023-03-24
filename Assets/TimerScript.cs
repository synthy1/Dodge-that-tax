using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    [Header("Refrenses")]
    public Text timerText;
    GameManager gameManager;

    [Header("Bools")]
    public bool gameStartl;

    [Header("floats")]
    float gameStartTimer = 30f;
    float timer;

    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        //Easy
        if(gameManager.dificulty == 0)
        {
            timer = 300f;
        }

        //Medium
        if (gameManager.dificulty == 1)
        {
            timer = 180f;
        }

        //Hard
        if (gameManager.dificulty == 2)
        {
            timer = 60f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timerText.enabled = false ;
        if (gameStartl)
        {
            timerText.text = timer.ToString("00:00");
            timerText.enabled = true;

            CountDown();
        }
    }

    private void CountDown()
    {
        timer = timer - Time.unscaledTime;

        if (timer == 10f)
        {
            timerText.color = Color.red;

            //Play sfx
        }
    }
}
