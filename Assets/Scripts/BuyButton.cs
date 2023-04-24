using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : WebInteractable
{

    public DoshScript doshAmount;

    public Image button;

    public float timeToClick = 1.5f;
    public float timeToClickAmmount;
    public float doshMin;
    public float doshMax;


    public override void ClickedOn()
    {
        // start timer make clicability false and take away x amount of money
        Debug.Log("clicked");
        if (timeToClickAmmount == timeToClick)
        {
            doshAmount.dosh -= Random.Range(doshMin, doshMax);
            timeToClickAmmount = 0f;
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
        if(timeToClickAmmount != timeToClick)
        {
            timeToClickAmmount += Time.deltaTime;

            //placeholder 
            button.color = Color.red;        
        }
        if (timeToClickAmmount > timeToClick)
        {
            timeToClickAmmount = timeToClick;
            //placeholder 
            button.color = Color.white;
        }
    }
}
