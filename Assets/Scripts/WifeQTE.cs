using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifeQTE : MonoBehaviour
{
    [Header("Refrenses")]
    public TimerScript time;
    public GameObject wifePhysical;
    public Transform startTransform;

    [Header("Settings")]
    public float qteChance;
    public float durationToCheck = 1;
   
    float checkTimer = 1;
    float wifeTimer = 0;
    float delayTimer = 0;
    bool active = false;
    bool stopWife = true;
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();

        //Easy
        if (GameManager.Instance.dificulty == 0)
        {
            qteChance = 0.1f;
        }

        //Medium
        if (GameManager.Instance.dificulty == 1)
        {
            qteChance = 0.3f;
        }

        //Hard
        if (GameManager.Instance.dificulty == 2)
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
            Debug.Log("stop");
            gameObject.transform.position = startTransform.position;
            Destroy(other.gameObject);
            wifePhysical.SetActive(false);
            stopWife = true;
            wifeTimer = 0f;
            active = false;
            
        }
    }

    void Wife()
    {


        if (stopWife == false)
        {
            wifeTimer += Time.deltaTime;

            transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);


            if (wifeTimer >= 25)
            {
                //run jumscare
                Debug.Log("Boo jumpscare");




                //delay end of game
                delayTimer += Time.deltaTime;
                if (delayTimer >= 5)
                {
                    time.gameStopl = true;
                    Debug.Log("endgame");
                }

            }
        }
        stopWife = false;
    }
}
