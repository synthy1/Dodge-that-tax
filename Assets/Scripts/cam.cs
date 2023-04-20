using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [Header("Refrences")]
    CharacterController playerBools;



    [Header("Settings")]
    public float sensX;
    public float sensY;

    [Header("references")]
    public Transform orient;
    public Transform player;
    public Transform snap1;
    public Transform snap2;
    public Transform snap3;
    public Rigidbody rbody;
    public Camera camera;

    public float rotationspeed;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerBools = GameObject.Find("Player").GetComponent<CharacterController>();
    }

    private void Update()
    {


        //----------------------------------------CAM------------------------------

        //free roam
        if (playerBools.freeRoam && !playerBools.sitting)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //setting the mouse value to a float and multiplying by our desired sensitivity
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            //rot cam
            yRotation += mouseX;

            xRotation -= mouseY;

            //clamps xaxis 90 <---> -90
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orient.rotation = Quaternion.Euler(0, yRotation, 0);
        }

        if(!playerBools.freeRoam && playerBools.sitting)
        {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (Input.GetKeyDown(KeyCode.D))
            {
                camera.transform.rotation = snap1.rotation;
                camera.transform.position = snap1.position;

            }

            else if (Input.GetKeyUp(KeyCode.D))
            {
                camera.transform.rotation = snap3.rotation;
                camera.transform.position = snap3.position;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                camera.transform.rotation = snap2.rotation;
                camera.transform.position = snap2.position;

            }

            else if (Input.GetKeyUp(KeyCode.A))
            {
                camera.transform.rotation = snap3.rotation;
                camera.transform.position = snap3.position;
            }

        }

    }

    //
}

