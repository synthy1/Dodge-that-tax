using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcScript : Interactable
{

    [Header("Refrenses")]
    public GameObject screenOne;
    public TimerScript time;

    public override void OnFocus()
    {

    }

    public override void OnInteract()
    {
        screenOne.SetActive(true);
        time.gameStartl = true;
    }

    public override void OnLoseFocus()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        screenOne.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
