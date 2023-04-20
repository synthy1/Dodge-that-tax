using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoshScript : MonoBehaviour
{

    [Header("Refrenses")]
    public Text doshText;
    GameManager gameManager;

    [Header("float")]
    public float dosh;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        //Easy
        if (gameManager.dificulty == 0)
        {
            dosh = 50000000f;
        }

        //Medium
        if (gameManager.dificulty == 1)
        {
            dosh = 100000000f;
        }

        //Hard
        if (gameManager.dificulty == 2)
        {
            dosh = 500000000f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        doshText.text = dosh.ToString("0");
    }
}
