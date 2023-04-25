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
    public GameObject hand1;
    public GameObject hand2;
    public Transform orient;
    public Transform player;
    public Transform snap1;
    public Transform snap2;
    public Transform snap3;
    public Transform camHolder;
    public Rigidbody rbody;
    public Camera camera;
    public Camera filtercamera;

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

        if (Input.GetKey(KeyCode.C))
        {
            filtercamera.fieldOfView = 20f;
        }

        else
        {
            filtercamera.fieldOfView = 60f;
        }

        //----------------------------------------CAM------------------------------

        //free roam
        if (playerBools.freeRoam && !playerBools.sitting)
        {

            camera.transform.SetParent(camHolder);
            hand1.SetActive(true);
            hand2.SetActive(true);

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

        if (!playerBools.freeRoam && playerBools.sitting)
        {

            camera.transform.SetParent(null);
            hand1.SetActive(false);
            hand2.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;


            if (Input.GetKeyDown(KeyCode.D))
            {
                LeanTween.move(camera.gameObject, snap1.transform.position, 0.1f);
                camera.transform.rotation = snap1.rotation;


            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                LeanTween.move(camera.gameObject, snap3.transform.position, 0.1f);
                camera.transform.rotation = snap3.rotation;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                LeanTween.move(camera.gameObject, snap2.transform.position, 0.1f);
                camera.transform.rotation = snap2.rotation;

            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                LeanTween.move(camera.gameObject, snap3.transform.position, 0.1f);
                camera.transform.rotation = snap3.rotation;
            }

        }

    }
}
