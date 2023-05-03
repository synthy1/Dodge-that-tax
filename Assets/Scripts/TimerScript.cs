using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    [Header("Refrenses")]
    public Text timerText;
    GameManager gameManager;
    public DoshScript money;

    [Header("Bools")]
    public bool gameStartl;
    public bool gameStopl = false;
    public bool gameWon = false;
    public bool gameLoss = false;

    [Header("floats")]
    public float timer;

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
        timerText.enabled = false;
        if (gameStartl && !gameStopl)
        {
            timerText.enabled = true;

            CountDown();
            TimeToDisplay(timer);
        }

        if (gameWon)
        {
            timerText.enabled = true;

            //Easy
            if (gameManager.dificulty == 0)
            {
                gameManager.beatEasy = true;
            }

            //Medium
            if (gameManager.dificulty == 1)
            {
                gameManager.beatMedium = true;
            }

            //Hard
            if (gameManager.dificulty == 2)
            {
                gameManager.beatHard = true;
            }
        }

        if (money.dosh <= 0f)
        {
            gameStopl = true;
            gameWon = true;
        }
    }

    private void CountDown()
    {


        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0f)
        {
            timer = 0f;
            gameLoss = true;
        }

        if (timer == 10f)
        {
            timerText.color = Color.red;

            //Play sfx
        }
    }

    private void TimeToDisplay(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
            gameStopl = true;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
