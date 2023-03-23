using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WebInteractable : MonoBehaviour
{
    public virtual void Awake()
    {
        gameObject.tag = "WebInt";
    }

    public abstract void Hover();


    public abstract void ClickedOn();

}
