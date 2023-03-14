using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    [Header("Settings")]
    public float sensX;
    public float sensY;

    [Header("references")]
    public Transform orient;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rbody;

    public float rotationspeed;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //rotate orientation
        Vector3 veiwDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orient.forward = veiwDir.normalized;

        //rot cam
        yRotation += horizontalInput;

        xRotation -= verticalInput;

        //clamps xaxis 90 <---> -90
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orient.rotation = Quaternion.Euler(0, yRotation, 0);

        //rotate player
        float horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * sensX;
        float verticalInput = Input.GetAxisRaw("Vertical") * Time.deltaTime * sensY;
        Vector3 inputDir = orient.forward * verticalInput + orient.right * horizontalInput;

        if(inputDir!= Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationspeed);
        }
    }
}
