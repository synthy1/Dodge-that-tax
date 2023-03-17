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


        //----------------------------------------CAM------------------------------

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
}
