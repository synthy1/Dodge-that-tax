using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBob : MonoBehaviour
{
    public CharacterController character;
    public float timeOffset = 1f;
    public float startOffset = -1f;
    public float bobDampener = 0.1f;
    public float bobSpeedDampener = 0.1f; 

    // Update is called once per frame
    void Update()
    {


        if(character.state == CharacterController.MovementState.walking)
        {
            float bob = Mathf.Sin((Time.time + timeOffset) * bobSpeedDampener) * bobDampener;
            transform.localPosition = new Vector3(transform.localPosition.x, startOffset + bob, transform.localPosition.z);
        }

        if (character.state == CharacterController.MovementState.sprinting)
        {
            float bob = Mathf.Sin((Time.time + timeOffset) * (bobSpeedDampener * 2f)) * bobDampener;
            transform.localPosition = new Vector3(transform.localPosition.x, startOffset + bob, transform.localPosition.z);
        }



    }
}
