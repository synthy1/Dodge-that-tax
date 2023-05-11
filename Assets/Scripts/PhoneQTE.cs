using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneQTE :Interactable
{
    [Header("Refrenses")]
    public TimerScript time;
    Animator animations;
    Transform startTransform;

    [Header("Settings")]
    public float qteChance;
    public float durationToCheck = 1;
    public float phoneDamage = 0.03f;
    float checkTimer = 1;
    public bool active = false;
    public bool stopRing = false;
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        startTransform = transform;
        animations = GetComponent<Animator>();
        sound = gameObject.GetComponent<AudioSource>();

        //Easy
        if (GameManager.Instance.dificulty == 0)
        {
            qteChance = 0.1f;
            phoneDamage = 0.03f;
        }

        //Medium
        if (GameManager.Instance.dificulty == 1)
        {
            qteChance = 0.3f;
            phoneDamage = 0.05f;
        }

        //Hard
        if (GameManager.Instance.dificulty == 2)
        {
            qteChance = 0.5f;
            phoneDamage = 0.09f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (time.gameStartl && !active)
        {
            checkTimer += Time.deltaTime;

            if (checkTimer > durationToCheck)
            {
                if (Random.value >= qteChance)
                {
                    active = true;
                }
                checkTimer = 0f;

            }



        }

        if (active)
        {
            stopRing = false;
            PhoneRing();
        }

        animations.SetBool("Active", active);

    }


    public override void OnInteract()
    {
        stopRing = true;
        active = false;
        sound.enabled = false;
        FindObjectOfType<TutorialManager>().hasInteractedWithPhone = true;
    }

    public override void OnFocus()
    {

    }

    public override void OnLoseFocus()
    {

    }

    void PhoneRing()
    {
        sound.enabled = true;


        if (checkTimer > durationToCheck/2f)
        {
            time.timer = time.timer - Random.Range(0.01f, phoneDamage);
            
        }
    }

    public override void OnPickUp()
    {

    }
}
