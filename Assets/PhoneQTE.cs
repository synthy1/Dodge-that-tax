using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneQTE : MonoBehaviour
{
    [Header("Refrenses")]
    GameManager gameManager;
    public AudioClip ringSFX;

    [Header("Settings")]
    public float qteChance;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        //Easy
        if (gameManager.dificulty == 0)
        {
            qteChance = 100f;
        }

        //Medium
        if (gameManager.dificulty == 1)
        {
            qteChance = 50f;
        }

        //Hard
        if (gameManager.dificulty == 2)
        {
            qteChance = 10f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
