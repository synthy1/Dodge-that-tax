using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakSound : MonoBehaviour
{
    public Transform intactObj;

    // Update is called once per frame
    void Update()
    {
        if(intactObj != null)
        {
            gameObject.transform.position = intactObj.position;
        }
    }
}
