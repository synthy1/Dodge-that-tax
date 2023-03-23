using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : WebInteractable
{
    public override void ClickedOn()
    {
        // start timer make clicability false and take away x amount of money
        Debug.Log("clicked");
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
        
    }
}
