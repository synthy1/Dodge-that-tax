using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trowable : Interactable
{

    [Header("refrenses")]
    public Transform holdingTrans;
    public GameObject breakableObject;

    [Header("bools")]
    public bool isPickedUp;

    [Header("inputs")]
    KeyCode throwInput = KeyCode.Mouse1;

    [Header("Settings")]
    public float throwIntecity = 1;


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
            gameObject.transform.position = holdingTrans.position;
            if (Input.GetKey(throwInput))
            {

                throwIntecity += Time.deltaTime;

            }

            if (Input.GetKeyUp(throwInput))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(holdingTrans.forward * throwIntecity, ForceMode.Impulse);
                throwIntecity = 1f;
                isPickedUp = false;
            }
        }

        if (throwIntecity >= 5)
        {
            throwIntecity = 5;
        }
    }
}
