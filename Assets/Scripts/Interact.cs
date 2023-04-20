using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private float raycastRange = 5f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private Transform pickUpTarget;
    [SerializeField] private float throwSpeed;
    public KeyCode interact = KeyCode.E;
    public KeyCode pickUp = KeyCode.F;
    public KeyCode throwInput = KeyCode.Mouse1;

    private Rigidbody currentRB;
    public Rigidbody player;

    // Update is called once per frame
    void Update()
    {



        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, raycastRange, interactableLayer))
        {
            var hitObjectInteract = hit.collider.GetComponent<Interactable>();
            if(hitObjectInteract != null)
            {

                if (Input.GetKeyDown(interact))
                {
                    hitObjectInteract.OnInteract();
                }

                if (Input.GetKeyDown(pickUp))
                {
                    if (currentRB)
                    {
                        currentRB.useGravity = true;
                        currentRB = null;
                        return;
                    }
                    currentRB = hit.rigidbody;
                    currentRB.useGravity = false;

                    Break br = hit.collider.GetComponent<Break>();

                    if (br != null)
                    {
                        br.thrown = false;
                    }
                }

                if (Input.GetKeyDown(throwInput))
                {

                    currentRB.useGravity = true;
                    currentRB.AddForce((player.transform.forward * throwSpeed) + player.velocity, ForceMode.Impulse);
                    currentRB = null;

                    Break br = hit.collider.GetComponent<Break>();

                    if (br != null)
                    {
                        br.thrown = true;
                    }
                }
            }

        }
    }
    void FixedUpdate()
    {
            if (currentRB)
            {
                Vector3 directiontopoint = pickUpTarget.position - currentRB.position;
                float distanceToPoint = directiontopoint.magnitude;

                currentRB.velocity = directiontopoint * 12 * distanceToPoint;


            }
    }
}
