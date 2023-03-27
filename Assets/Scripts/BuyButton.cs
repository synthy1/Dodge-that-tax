using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : WebInteractable
{

    public DoshScript doshAmount;

    public Image button;

    public float timeToClick = 1.5f;


    public override void ClickedOn()
    {
        // start timer make clicability false and take away x amount of money
        Debug.Log("clicked");
        if (timeToClick == 1.5f)
        {
            doshAmount.dosh -= Random.Range(20000f, 27000f);
            timeToClick = 0f;
        }

    }

    public override void Hover()
    {
        //animate hover
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToClick != 1.5f)
        {
            timeToClick += Time.deltaTime;

            //placeholder 
            button.color = Color.red;        
        }
        if (timeToClick > 1.5f)
        {
            timeToClick = 1.5f;
            //placeholder 
            button.color = Color.white;
        }
    }
}
