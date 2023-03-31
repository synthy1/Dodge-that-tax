using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{

    public GameObject breakableObj;

    [SerializeField] public bool thrown ;

    public void OnCollisionEnter(Collision collision)
    {
        if (thrown)
        {
            BreakThatThing();
        }
    }

    public void BreakThatThing()
    {
        GameObject frac = Instantiate(breakableObj, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
