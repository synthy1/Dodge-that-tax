using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
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
    }

    private void Update()
    {


        //----------------------------------------CAM------------------------------

        //free roam
        if (playerBools.freeRoam && !playerBools.sitting)
        {
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
            if (Input.GetKeyDown(KeyCode.A))
            {
                camera.transform.rotation = Quaternion.Euler(snap1.rotation.x, snap1.rotation.y, snap1.rotation.z);
                camera.transform.localPosition = snap1.localPosition;

            }

            else if (Input.GetKeyUp(KeyCode.A))
            {
                camera.transform.rotation = Quaternion.Euler(snap3.rotation.x, snap3.rotation.y, snap3.rotation.z);
                camera.transform.localPosition = snap3.localPosition;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                camera.transform.rotation = Quaternion.Euler(snap2.rotation.x, snap2.rotation.y, snap2.rotation.z);
                camera.transform.localPosition = snap2.localPosition;

            }

            else if (Input.GetKeyUp(KeyCode.D))
            {
                camera.transform.rotation = Quaternion.Euler(snap3.rotation.x, snap3.rotation.y, snap3.rotation.z);
                camera.transform.localPosition = snap3.localPosition;
            }

        }

    }


}
}
