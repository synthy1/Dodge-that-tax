using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : Interactable
{
    [Header("Refrences")]
    CharacterController player;
    public Transform chairCam;
    public Camera mainCam;

    public override void OnFocus()
    {
        //highlight object
    }

    public override void OnInteract()
    {
        player.freeRoam = false;
        player.sitting = true;

        mainCam.transform.position = chairCam.transform.position;
        mainCam.transform.rotation = chairCam.transform.rotation;

        Debug.Log("interacted");
    }

    public override void OnLoseFocus()
    {
        //Unhighlight
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<CharacterController>();
    }

}
