using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private float raycastRange = 5f;
    [SerializeField] private LayerMask interactableLayer;
    public KeyCode interact = KeyCode.E;

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
            }

        }
    }
}
