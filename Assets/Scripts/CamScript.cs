using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    [Header("Refrences")]
    public Transform camPosOne;
    public Transform camPostwo;
    public Camera mainCam;
    public Transform orient;
    public Transform Player;
    public Transform Player_obj;
    public Rigidbody rbody;

    [Header("booleans")]
    [SerializeField] private bool freeLook = true; 
    [SerializeField] private bool pcLook = false; 

    [Header("Settings")]
    public float rotationspeed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (freeLook)
        {
            FreeLook();
        }

        else if (pcLook)
        {

        }
    }

    void FreeLook()
    {
        //rotate orientation
        Vector3 veiwDir = Player.position - new Vector3(transform.position.x, Player.position.y, transform.position.z);
        orient.forward = veiwDir.normalized;

        //rotate player
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 inputDir = orient.forward * verticalInput + orient.right * horizontalInput;

        if (inputDir != Vector3.zero)
        {
            Player_obj.forward = Vector3.Slerp(Player_obj.forward, inputDir.normalized, Time.deltaTime * rotationspeed);
        }
    }
}
