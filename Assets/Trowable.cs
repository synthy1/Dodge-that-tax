using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trowable : Interactable
{

    [Header("refrenses")]
    public Transform holdingTrans;
    public GameObject breakableObject;
    public Rigidbody playerRB;

    [Header("bools")]
    public bool isPickedUp;

    [Header("inputs")]
    KeyCode throwInput = KeyCode.Mouse1;

    [Header("Settings")]
    public float throwIntecity = 50;


    public override void OnFocus()
    {

    }

    public override void OnInteract()
    {

    }

    public override void OnLoseFocus()
    {

    }

    public override void OnPickUp()
    {
        isPickedUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickedUp)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.transform.position = holdingTrans.position;
            gameObject.transform.rotation = holdingTrans.rotation;
            if (Input.GetKey(throwInput))
            {

                throwIntecity += 1;

            }

            if (Input.GetKeyUp(throwInput))
            {
                gameObject.GetComponent<Rigidbody>().AddForce((holdingTrans.forward * throwIntecity) + playerRB.velocity, ForceMode.Impulse);
                throwIntecity = 50f;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                isPickedUp = false;
            }
        }

        if (throwIntecity >= 100)
        {
            throwIntecity = 100;
        }
    }
}
