using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneQTE :Interactable
{
    [Header("Refrenses")]
    GameManager gameManager;
    public AudioClip ringSFX;
    public TimerScript time;

    [Header("Settings")]
    public float qteChance;
    public float durationToCheck = 1;
    public float phoneDamage = 0.03f;
    float checkTimer = 1;
    bool active = false;
    bool stopRing = false;
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
            phoneDamage = 0.03f;
        }

        //Medium
        if (gameManager.dificulty == 1)
        {
            qteChance = 0.3f;
            phoneDamage = 0.05f;
        }

        //Hard
        if (gameManager.dificulty == 2)
        {
            qteChance = 0.5f;
            phoneDamage = 0.09f;
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
                    Debug.Log("ran");
                    active = true;
                }
                checkTimer = 0f;

            }


            if (active)
            {
                stopRing = false;
                PhoneRing();
            }
        }



    }


    public override void OnInteract()
    {
        stopRing = true;
        active = false;
        sound.Stop();
    }

    public override void OnFocus()
    {

    }

    public override void OnLoseFocus()
    {

    }

    void PhoneRing()
    {
        sound.PlayOneShot(ringSFX);

        Debug.Log("phone");

        if (checkTimer > durationToCheck/2f)
        {
            time.timer = time.timer - Random.Range(0.01f, phoneDamage);
            Debug.Log("time deduct");
            
        }
    }

    public override void OnPickUp()
    {

    }
}
