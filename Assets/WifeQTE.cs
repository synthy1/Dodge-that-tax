using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifeQTE : MonoBehaviour
{
    [Header("Refrenses")]
    GameManager gameManager;
    public TimerScript time;
    public GameObject wifePhysical;

    [Header("Settings")]
    public float qteChance;
    public float durationToCheck = 1;
   
    float checkTimer = 1;
    float wifeTimer = 0;
    float delayTimer = 0;
    bool active = false;
    bool stopWife = false;
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        //Easy
        if (gameManager.dificulty == 0)
        {
            qteChance = 0.1f;
        }

        //Medium
        if (gameManager.dificulty == 1)
        {
            qteChance = 0.3f;
        }

        //Hard
        if (gameManager.dificulty == 2)
        {
            qteChance = 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (time.gameStartl)
        {
            checkTimer += Time.deltaTime;

            if (checkTimer > durationToCheck)
            {
                if (Random.value >= qteChance && !active)
                {
                    active = true;
                }
                checkTimer = 0f;

            }


            if (active)
            {
                wifePhysical.SetActive(true);
                stopWife = false;
                Wife();
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dosh"))
        {
            stopWife = true;
            wifeTimer = 0f;
            
        }
    }

    void Wife()
    {
        stopWife = false;

        if (!stopWife)
        {
            wifeTimer += Time.deltaTime;

            transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);


            if (wifeTimer <= 600)
            {
                //run jumscare
                Debug.Log("Boo jumpscare");




                //delay end of game
                delayTimer += Time.deltaTime;
                if (delayTimer <= 10)
                {
                    time.gameStopl = true;
                    Debug.Log("endgame");
                }

            }
        }

    }
}