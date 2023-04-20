using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{

    public GameObject breakableObj;
    public float breakForce = 10;

    [SerializeField] public bool thrown = false;

    public bool decor = false;

    public void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.CompareTag("DecorBreak"))
        {
            Debug.Log("1: " + collision.gameObject.tag + collision.gameObject.name);

            if (thrown)
            {
                BreakThatThing();
            }
        }
        
        if (collision.gameObject.CompareTag("EnviroBreak"))
        {
            Debug.Log("1: " + collision.gameObject.tag + collision.gameObject.name);

            BreakThatThing();
        }*/

        if (collision.impactForceSum.magnitude > 1f)
        {
            if(!decor)
            {
                BreakThatThing(collision.impactForceSum * -breakForce);
            }

            if (decor)
            {
                if (thrown)
                {
                    BreakThatThing(collision.impactForceSum * -breakForce);
                }
            }

        } 
    }

    public void BreakThatThing(Vector3 force)
    {

        GameObject frac = Instantiate(breakableObj, transform.position, transform.rotation);
        
        foreach(Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>())
        {
            
            rb.AddForce(force);
        }

        Destroy(gameObject);
    }
}
