using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoshScript : MonoBehaviour
{

    [Header("Refrenses")]
    public Text doshText;

    [Header("float")]
    public float dosh;

    // Start is called before the first frame update
    void Start()
    {
        //Easy
        if (GameManager.Instance.dificulty == 0)
        {
            dosh = 50000000f;
        }

        //Medium
        if (GameManager.Instance.dificulty == 1)
        {
            dosh = 100000000f;
        }

        //Hard
        if (GameManager.Instance.dificulty == 2)
        {
            dosh = 500000000f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        doshText.text = dosh.ToString("0");


        if(dosh <= 0)
        {
            dosh = 0;
        }
    }
}
